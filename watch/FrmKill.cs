using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace watch
{
    public partial class FrmKill : Form
    {
        public FrmKill()
        {
            InitializeComponent();
        }
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        private void FrmKill_Load(object sender, EventArgs e)
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                if (now.Second == 0 && now.Minute == 30 && now.Hour == 2)
                {
                    Process[] pros = Process.GetProcesses();
                    bool exist = false;
                    foreach (Process p in pros)
                    {
                        if (p.ProcessName == "用电信息采集前置机")
                        {
                            p.Kill();
                            exist = true;

                        }
                    }
                    if (exist)
                    {
                        richTextBox1.AppendText("杀死成功-----" + now.ToString() + "-----\n");
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message + "\n");
            }
        }
    }
}
