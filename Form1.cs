using Peak.Can.Basic;
using System.Diagnostics;
using System.Threading.Channels;


namespace PCanMiniView
{
    public partial class Form1 : Form
    {
        private PcanChannel channel;
        private PcanStatus result;
        private List<CanMessage> canMessages = new List<CanMessage>();

        public Form1()
        {
            InitializeComponent();

            channel = PcanChannel.Usb01;
            result = Api.Initialize(channel, Bitrate.Pcan250);

            if (result != PcanStatus.OK)
            {
                Api.GetErrorText(result, out var errorText);
                MessageBox.Show(errorText, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            channelTxBox.Text = channel.ToString();
            baudRateTxBox.Text = Bitrate.Pcan250.ToString();

            readTimer.Start();
            viewTimer.Start();


        }

        private void ProcessMessage(PcanMessage msg, ulong msgTimeStamp = 0)
        {
            foreach (CanMessage lstMsg in canMessages)
            {
                if (lstMsg.Msg.ID == msg.ID)
                {
                    lstMsg.UpdateMsg(msg, msgTimeStamp);
                    return;
                }
            }

            CanMessage canMsg = new CanMessage(msg, msgTimeStamp, msgViewList.Items.Count);
            canMessages.Add(canMsg);

            ListViewItem newlstItem = msgViewList.Items.Add(canMsg.Msg.MsgType.ToString());
            newlstItem.SubItems.Add(canMsg.Msg.ID.ToString("X8"));
            newlstItem.SubItems.Add(canMsg.Msg.Length.ToString());
            newlstItem.SubItems.Add(BitConverter.ToString(canMsg.Msg.Data).Replace("-", " "));
            newlstItem.SubItems.Add(canMsg.MsgTime.ToString());
            newlstItem.SubItems.Add(canMsg.MsgCount.ToString());
        }

        private void SendMessage()
        {
            PcanMessage msg = new PcanMessage(0x200, MessageType.Extended, 8, null, false);
            msg.Data = new byte[8];

            for (int i = 0; i < 8; i++)
            {
                msg.Data[i] = 0x99;
            }

            result = Api.Write(channel, msg);

            if (result == PcanStatus.OK)
            {
                ProcessMessage(msg);
            }
            else
            {
                Api.GetErrorText(result, out var errorText);
                MessageBox.Show(errorText, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ReadTimer_Tick(object sender, EventArgs e)
        {

            PcanMessage msg;
            ulong msgTimeStamp;

            do
            {
                result = Api.Read(channel, out msg, out msgTimeStamp);
                if (result == PcanStatus.OK)
                {
                    ProcessMessage(msg, msgTimeStamp);
                }
                else
                {
                    if ((result & PcanStatus.ReceiveQueueEmpty) != PcanStatus.ReceiveQueueEmpty)
                    {
                        Api.GetErrorText(result, out var errorText);
                        Debug.WriteLine(errorText);
                        break;
                    }
                }

            } while ((result & PcanStatus.ReceiveQueueEmpty) != PcanStatus.ReceiveQueueEmpty);

        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            ListViewItem lstItem;

            foreach (CanMessage lstMsg in canMessages)
            {
                lstItem = msgViewList.Items[lstMsg.MsgIdx];

                lstItem.SubItems[2].Text = lstMsg.Msg.Length.ToString();
                lstItem.SubItems[3].Text = BitConverter.ToString(lstMsg.Msg.Data).Replace("-", " ");
                lstItem.SubItems[4].Text = lstMsg.MsgTime.ToString();
                lstItem.SubItems[5].Text = lstMsg.MsgCount.ToString();
            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            readTimer.Stop();
            viewTimer.Stop();
            Api.Uninitialize(channel);
        }

        private void msgSendBtn_Click(object sender, EventArgs e)
        {
            SendMessage();
        }


        // 화면 깜빡임 없애기
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
