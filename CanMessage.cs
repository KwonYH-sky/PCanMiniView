using Peak.Can.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCanMiniView
{
    internal class CanMessage
    {
        private PcanMessage msg;
        private ulong msgTime;
        private int msgIdx;
        private int msgCount;

        public CanMessage(PcanMessage msg, ulong msgTime, int msgIdx)
        {
            this.msg = msg;
            this.msgTime = msgTime;
            this.msgIdx = msgIdx;
            this.msgCount = 1;
        }

        public void UpdateMsg(PcanMessage msg, ulong msgTimeStamp)
        {
            this.msg = msg;
            this.msgTime = msgTimeStamp;
            msgCount++;
        }

        public PcanMessage Msg
        {
            get { return msg; }
        }

        public ulong MsgTime
        {
            get { return msgTime; }
        }

        public int MsgIdx
        {
            get { return msgIdx; }
        }

        public int MsgCount
        {
            get { return msgCount; }
        }

    }
}