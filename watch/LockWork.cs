using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace watch
{
    public partial class LockWork : Form
    {
        public LockWork()
        {
            InitializeComponent();
        }
        [DllImport("user32")]
        public static extern bool LockWorkStation();//这个是调用windows的系统锁定
        System.Timers.Timer lockTime = new System.Timers.Timer(1000);
        List<int> hours = new List<int>();
        private void LockWork_Load(object sender, EventArgs e)
        {
            lockTime.Elapsed += LockTime_Elapsed;
            lockTime.Enabled = true;
            int[] h = { 9, 10, 11, 14, 15, 16, 17 };
            hours = new List<int>(h);
        }

        private void LockTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DateTime n = DateTime.Now;
                if (n.DayOfWeek == DayOfWeek.Saturday || n.DayOfWeek == DayOfWeek.Sunday)
                {
                    return;
                }
                if (n.Minute == 11 && n.Second == 0
                    &&hours.Contains(n.Hour))
                {
                    LockWorkStation();
                }
            }
            catch
            {
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Msg2("你确定要退出监听程序吗？");
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }
    }
}
