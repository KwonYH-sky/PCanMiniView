namespace PCanMiniView
{

    /*
     * ListView 깜박임 방지
     */
    internal class ListViewNF : System.Windows.Forms.ListView
    {
        public ListViewNF()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(System.Windows.Forms.Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
