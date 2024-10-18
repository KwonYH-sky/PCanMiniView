using Peak.Can.Basic;
using System.Diagnostics;


namespace PCanMiniView
{
    public partial class Form1 : Form
    {
        private PcanChannel channel;
        private PcanStatus result;
        private readonly List<CanMessage> canMessages = new List<CanMessage>();

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
                if (lstMsg.Msg.ID == msg.ID && lstMsg.Msg.MsgType == msg.MsgType)
                {
                    lstMsg.UpdateMsg(msg, msgTimeStamp);
                    return;
                }
            }

            CanMessage canMsg = new CanMessage(msg, msgTimeStamp, msgViewList.Items.Count);
            canMessages.Add(canMsg);

            ListViewItem newlstItem = msgViewList.Items.Add(canMsg.Msg.MsgType.ToString());
            newlstItem.SubItems.Add((canMsg.Msg.MsgType == MessageType.Extended ? canMsg.Msg.ID.ToString("X8") : canMsg.Msg.ID.ToString("X3")) + 'h');
            newlstItem.SubItems.Add(canMsg.Msg.Length.ToString());
            newlstItem.SubItems.Add(BitConverter.ToString(canMsg.Msg.Data).Replace("-", " "));
            newlstItem.SubItems.Add(((canMsg.MsgTime - canMsg.MsgPrevTime) * 0.001).ToString("F1"));
            newlstItem.SubItems.Add(canMsg.MsgCount.ToString());
        }

        private void SendMessage(string id, string len, string data, bool isExtended)
        {
            PcanMessage msg = new PcanMessage
            {
                ID = GetIDFromText(id, isExtended),
                MsgType = isExtended ? MessageType.Extended : MessageType.Standard,
                DLC = Convert.ToByte(len),
                Data = new byte[Convert.ToUInt16(len)]
            };

            byte[] dataByteArr = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();

            for (int i = 0; i < msg.Data.MaxLength; i++)
            {
                msg.Data[i] = dataByteArr[i];
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

            do
            {
                result = Api.Read(channel, out PcanMessage msg, out ulong msgTimeStamp);
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
                lstItem.SubItems[4].Text = ((lstMsg.MsgTime - lstMsg.MsgPrevTime) * 0.001).ToString("F1");
                lstItem.SubItems[5].Text = lstMsg.MsgCount.ToString();
            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            readTimer.Stop();
            viewTimer.Stop();
            Api.Uninitialize(channel);
        }

        private void MsgSendBtn_Click(object sender, EventArgs e)
        {
            string writeID = wIDTxBox.Text;
            string writeLEN = wLenTxBox.Text;
            string writeData = wDataTxBox.Text;
            bool isExt = wIsExtendedCkBox.Checked;

            if (IsBlank(writeID) || IsBlank(writeLEN) || IsBlank(writeData))
            {
                MessageBox.Show("ID, 길이, 데이터를 입력해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SendMessage(writeID, writeLEN, writeData, isExt);
        }

        private void WLenTxBox_TextChanged(object sender, EventArgs e)
        {
            int len = Convert.ToInt32(wLenTxBox.Text);

            if (len <= 0 || IsBlank(wLenTxBox.Text))
            {
                len = 0;
                wLenTxBox.Text = "0";
                wDataTxBox.Enabled = false;
                wDataTxBox.ReadOnly = true;
            }
            else
            {
                wDataTxBox.Enabled = true;
                wDataTxBox.ReadOnly = false;
            }

            if (len > 8)
            {
                len = 8;
                wLenTxBox.Text = "8";
            }

            string[] data = new string[len];

            for (int i = 0; i < len; i++)
            {
                data[i] = "00";
            }

            wDataTxBox.Text = string.Join(" ", data);
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

        private static bool IsBlank(string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        // ID 범위에 맞게 변환
        // 11bit : 0x7FF
        // 29bit : 0x1FFFFFFF
        private uint GetIDFromText(string id, bool isExtended)
        {
            ulong intId = Convert.ToUInt64(id, 16);

            if (!isExtended && intId > 0x7FF)
                intId = 0x7FF;
            else if (isExtended && intId > 0x1FFFFFFF)
                intId = 0x1FFFFFFF;

            return (uint)intId;
        }

        private void wIDTxBox_TextChanged(object sender, EventArgs e)
        {
            wIDTxBox.Text = GetIDFromText(wIDTxBox.Text, wIsExtendedCkBox.Checked).ToString("X");
        }
    }
}
