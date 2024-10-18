 namespace PCanMiniView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            msgViewList = new ListView();
            colHMsgType = new ColumnHeader();
            colHMshId = new ColumnHeader();
            colHMsgLen = new ColumnHeader();
            colHMsgData = new ColumnHeader();
            colHMsgTimeStamp = new ColumnHeader();
            colHMsgCnt = new ColumnHeader();
            readTimer = new System.Windows.Forms.Timer(components);
            viewTimer = new System.Windows.Forms.Timer(components);
            channelTxBox = new TextBox();
            channelLabel = new Label();
            baudRateLabel = new Label();
            baudRateTxBox = new TextBox();
            msgSendBtn = new Button();
            writeGroupBox = new GroupBox();
            wDataLabel = new Label();
            wLenLabel = new Label();
            wDataTxBox = new TextBox();
            wIsExtendedCkBox = new CheckBox();
            wLenTxBox = new TextBox();
            wIDLabel = new Label();
            wIDTxBox = new TextBox();
            writeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // msgViewList
            // 
            msgViewList.Columns.AddRange(new ColumnHeader[] { colHMsgType, colHMshId, colHMsgLen, colHMsgData, colHMsgTimeStamp, colHMsgCnt });
            msgViewList.Location = new Point(12, 78);
            msgViewList.Name = "msgViewList";
            msgViewList.Size = new Size(547, 142);
            msgViewList.TabIndex = 0;
            msgViewList.UseCompatibleStateImageBehavior = false;
            msgViewList.View = View.Details;
            // 
            // colHMsgType
            // 
            colHMsgType.Text = "타입";
            // 
            // colHMshId
            // 
            colHMshId.Text = "ID";
            colHMshId.Width = 100;
            // 
            // colHMsgLen
            // 
            colHMsgLen.Text = "길이";
            colHMsgLen.Width = 40;
            // 
            // colHMsgData
            // 
            colHMsgData.Text = "데이터";
            colHMsgData.Width = 180;
            // 
            // colHMsgTimeStamp
            // 
            colHMsgTimeStamp.Text = "사이클 타임";
            colHMsgTimeStamp.Width = 75;
            // 
            // colHMsgCnt
            // 
            colHMsgCnt.Text = "카운트";
            // 
            // readTimer
            // 
            readTimer.Interval = 50;
            readTimer.Tick += ReadTimer_Tick;
            // 
            // viewTimer
            // 
            viewTimer.Tick += ViewTimer_Tick;
            // 
            // channelTxBox
            // 
            channelTxBox.Location = new Point(61, 25);
            channelTxBox.Name = "channelTxBox";
            channelTxBox.ReadOnly = true;
            channelTxBox.Size = new Size(100, 23);
            channelTxBox.TabIndex = 1;
            // 
            // channelLabel
            // 
            channelLabel.AutoSize = true;
            channelLabel.Location = new Point(12, 28);
            channelLabel.Name = "channelLabel";
            channelLabel.Size = new Size(31, 15);
            channelLabel.TabIndex = 2;
            channelLabel.Text = "채널";
            // 
            // baudRateLabel
            // 
            baudRateLabel.AutoSize = true;
            baudRateLabel.Location = new Point(187, 28);
            baudRateLabel.Name = "baudRateLabel";
            baudRateLabel.Size = new Size(74, 15);
            baudRateLabel.TabIndex = 3;
            baudRateLabel.Text = "Baud 레이트";
            // 
            // baudRateTxBox
            // 
            baudRateTxBox.Location = new Point(267, 25);
            baudRateTxBox.Name = "baudRateTxBox";
            baudRateTxBox.ReadOnly = true;
            baudRateTxBox.Size = new Size(100, 23);
            baudRateTxBox.TabIndex = 4;
            // 
            // msgSendBtn
            // 
            msgSendBtn.Location = new Point(6, 201);
            msgSendBtn.Name = "msgSendBtn";
            msgSendBtn.Size = new Size(527, 23);
            msgSendBtn.TabIndex = 5;
            msgSendBtn.Text = "메시지 보내기";
            msgSendBtn.UseVisualStyleBackColor = true;
            msgSendBtn.Click += MsgSendBtn_Click;
            // 
            // writeGroupBox
            // 
            writeGroupBox.Controls.Add(wDataLabel);
            writeGroupBox.Controls.Add(wLenLabel);
            writeGroupBox.Controls.Add(wDataTxBox);
            writeGroupBox.Controls.Add(wIsExtendedCkBox);
            writeGroupBox.Controls.Add(wLenTxBox);
            writeGroupBox.Controls.Add(wIDLabel);
            writeGroupBox.Controls.Add(wIDTxBox);
            writeGroupBox.Controls.Add(msgSendBtn);
            writeGroupBox.Location = new Point(12, 226);
            writeGroupBox.Name = "writeGroupBox";
            writeGroupBox.Size = new Size(547, 230);
            writeGroupBox.TabIndex = 6;
            writeGroupBox.TabStop = false;
            writeGroupBox.Text = "메시지 보내기";
            // 
            // wDataLabel
            // 
            wDataLabel.AutoSize = true;
            wDataLabel.Location = new Point(12, 83);
            wDataLabel.Name = "wDataLabel";
            wDataLabel.Size = new Size(43, 15);
            wDataLabel.TabIndex = 12;
            wDataLabel.Text = "데이터(HEX)";
            // 
            // wLenLabel
            // 
            wLenLabel.AutoSize = true;
            wLenLabel.Location = new Point(12, 59);
            wLenLabel.Name = "wLenLabel";
            wLenLabel.Size = new Size(31, 15);
            wLenLabel.TabIndex = 11;
            wLenLabel.Text = "길이";
            // 
            // wDataTxBox
            // 
            wDataTxBox.Location = new Point(6, 101);
            wDataTxBox.Multiline = true;
            wDataTxBox.Name = "wDataTxBox";
            wDataTxBox.PlaceholderText = "공백 포함해야함";
            wDataTxBox.ReadOnly = true;
            wDataTxBox.Size = new Size(527, 94);
            wDataTxBox.TabIndex = 10;
            // 
            // wIsExtendedCkBox
            // 
            wIsExtendedCkBox.AutoSize = true;
            wIsExtendedCkBox.Location = new Point(168, 29);
            wIsExtendedCkBox.Name = "wIsExtendedCkBox";
            wIsExtendedCkBox.Size = new Size(50, 19);
            wIsExtendedCkBox.TabIndex = 9;
            wIsExtendedCkBox.Text = "확장";
            wIsExtendedCkBox.UseVisualStyleBackColor = true;
            // 
            // wLenTxBox
            // 
            wLenTxBox.Location = new Point(62, 56);
            wLenTxBox.Name = "wLenTxBox";
            wLenTxBox.Size = new Size(100, 23);
            wLenTxBox.TabIndex = 8;
            wLenTxBox.Text = "0";
            wLenTxBox.TextChanged += WLenTxBox_TextChanged;
            // 
            // wIDLabel
            // 
            wIDLabel.AutoSize = true;
            wIDLabel.Location = new Point(12, 30);
            wIDLabel.Name = "wIDLabel";
            wIDLabel.Size = new Size(19, 15);
            wIDLabel.TabIndex = 7;
            wIDLabel.Text = "ID";
            // 
            // wIDTxBox
            // 
            wIDTxBox.Location = new Point(62, 27);
            wIDTxBox.Name = "wIDTxBox";
            wIDTxBox.Size = new Size(100, 23);
            wIDTxBox.TabIndex = 6;
            wIDTxBox.Text = "000";
            wIDTxBox.TextChanged += wIDTxBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 473);
            Controls.Add(baudRateTxBox);
            Controls.Add(baudRateLabel);
            Controls.Add(channelLabel);
            Controls.Add(channelTxBox);
            Controls.Add(msgViewList);
            Controls.Add(writeGroupBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "PCanMiniView";
            FormClosing += Form1_FormClosing;
            writeGroupBox.ResumeLayout(false);
            writeGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView msgViewList;
        private System.Windows.Forms.Timer readTimer;
        private System.Windows.Forms.Timer viewTimer;
        private TextBox channelTxBox;
        private Label channelLabel;
        private Label baudRateLabel;
        private TextBox baudRateTxBox;
        private ColumnHeader colHMsgType;
        private ColumnHeader colHMshId;
        private ColumnHeader colHMsgData;
        private ColumnHeader colHMsgLen;
        private ColumnHeader colHMsgTimeStamp;
        private ColumnHeader colHMsgCnt;
        private Button msgSendBtn;
        private GroupBox writeGroupBox;
        private TextBox wIDTxBox;
        private Label wIDLabel;
        private CheckBox wIsExtendedCkBox;
        private TextBox wLenTxBox;
        private TextBox wDataTxBox;
        private Label wDataLabel;
        private Label wLenLabel;
    }
}
