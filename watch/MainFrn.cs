using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace watch
{
    public partial class MainFrn : Form
    {
        public MainFrn()
        {
            InitializeComponent();
            System.Timers.Timer Twatch = new System.Timers.Timer();
            Twatch.Interval = 30000;
            Twatch.Elapsed += Twatch_Elapsed;
            Twatch.Enabled = true;
            System.Timers.Timer Twork = new System.Timers.Timer();
            Twork.Interval = 60000;
            Twork.Elapsed += Twork_Elapsed;
            Twork.Enabled = true;
            System.Timers.Timer logTimer = new System.Timers.Timer();
            logTimer.Interval = 1000;
            logTimer.Enabled = true;
            logTimer.Elapsed += LogTimer_Elapsed;
        }

        private void LogTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime n = DateTime.Now;
            if (n.Minute == 55 && n.Second == 10)
            {
                if (!Directory.Exists(Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd"));
                }
                try
                {
                    richTextBox1.SaveFile(Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt ", RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText(ex.Message);
                }
                finally
                {
                    richTextBox1.Clear();
                }
            }
        }

        DateTime Dstrat = new DateTime();
        private void Twork_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                TimeSpan ts = DateTime.Now - Dstrat;
                labelX1.Text = "本程序已运行" + ts.Days + "天" + ts.Hours + "小时" + ts.Minutes + "分钟";

                #region 写给备用前置机 杀死进程用
                //DateTime ns = DateTime.Now;
                //if (ns.Hour < 8 || ns.Hour > 20)
                //{
                //    Process[] pce = Process.GetProcesses();
                //    bool Ion = false;
                //    foreach (Process p in pce)
                //    {
                //        if (p.ProcessName == "用电信息采集前置机")
                //        {
                //            p.Kill();
                //        }
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
        int co = 0;
        private void Twatch_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (File.Exists("config.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("config.xml");
                    XmlNodeList items = doc.SelectNodes("con/item");
                    richTextBox1.AppendText("加载完成配置文件,共检测程序" + items.Count + "个\n");
                    foreach (XmlNode item in items)
                    {
                        if (!string.IsNullOrEmpty(item.Attributes["path"].Value))
                        {
                            Process[] pce = Process.GetProcesses();
                            bool Ion = false;
                            foreach (Process p in pce)
                            {
                                if (p.ProcessName == item.Attributes["name"].Value)
                                {
                                    try
                                    {
                                        //if (item.Attributes["path"].Value == p.MainModule.FileName)
                                        {
                                            Ion = true;
                                            if (co == 0)
                                            {
                                                //richTextBox1.AppendText("检测到" + p.ProcessName + "进程 \n");
                                            }
                                            co++;
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        p.Close();
                                    }
                                }
                            }
                            if (!Ion)
                            {
                                richTextBox1.AppendText("未检测到" + item.Attributes["name"].Value + "，启动程序 \n");
                                Process.Start(item.Attributes["path"].Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("定时器异常:" + ex.Message);
            }
        }

        private void MainFrn_Load(object sender, EventArgs e)
        {
            try
            {
                InitLoad();
                Dstrat = DateTime.Now;
            }
            catch
            {

            }
        }
        private void InitLoad()
        {
            try
            {
                dataGridViewX1.Rows.Clear();
                XmlDocument doc = new XmlDocument();
                if (File.Exists("config.xml"))
                {
                    doc.Load("config.xml");
                    XmlNode con = doc.SelectSingleNode("con");
                    if (con != null)
                    {
                        XmlNodeList items = con.SelectNodes("item");
                        foreach (XmlNode item in items)
                        {
                            string id = item.Attributes["id"].Value;
                            string name = item.Attributes["name"].Value;
                            string path = item.Attributes["path"].Value;
                            int index = dataGridViewX1.Rows.Add();
                            dataGridViewX1.Rows[index].Cells[0].Value = id;
                            dataGridViewX1.Rows[index].Cells[1].Value = name;
                            dataGridViewX1.Rows[index].Cells[2].Value = path;
                        }
                    }
                }
                else
                {
                    var con = doc.CreateElement("con");
                    doc.AppendChild(con);
                    XmlElement item = doc.CreateElement("item");
                    XmlAttribute id = doc.CreateAttribute("id");
                    id.Value = DateTime.Now.ToString("yyyyMMHHmmss");
                    item.Attributes.Append(id);
                    XmlAttribute name = doc.CreateAttribute("name");
                    name.Value = "测试";
                    item.Attributes.Append(name);
                    XmlAttribute path = doc.CreateAttribute("path");
                    path.Value = "";
                    item.Attributes.Append(path);
                    con.AppendChild(item);
                    doc.Save("config.xml");
                    int index = dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[index].Cells[0].Value = id;
                    dataGridViewX1.Rows[index].Cells[1].Value = name;
                    dataGridViewX1.Rows[index].Cells[2].Value = path;
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("InitLoad---" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "程序|*.exe";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string Nid = DateTime.Now.ToString("yyyyMMHHmmss");
                    string Npath = open.FileName;
                    string safeName = open.FileName.Substring(open.FileName.LastIndexOf(@"\") + 1);//获取选中的文件名
                    string Nname = safeName.Substring(0, safeName.IndexOf(".exe"));
                    XmlDocument doc = new XmlDocument();
                    XmlElement item = doc.CreateElement("item");
                    XmlAttribute id = doc.CreateAttribute("id");
                    id.Value = Nid;
                    item.Attributes.Append(id);
                    XmlAttribute name = doc.CreateAttribute("name");
                    name.Value = Nname;
                    item.Attributes.Append(name);
                    XmlAttribute path = doc.CreateAttribute("path");
                    path.Value = Npath;
                    item.Attributes.Append(path);
                    if (File.Exists("config.xml"))
                    {
                        doc.Load("config.xml");
                        XmlNode con = doc.SelectSingleNode("con");
                        if (con == null)
                        {
                            con = doc.CreateElement("con");
                        }
                        con.AppendChild(item);
                    }
                    doc.Save("config.xml");

                    int index = dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[index].Cells[0].Value = Nid;
                    dataGridViewX1.Rows[index].Cells[1].Value = Nname;
                    dataGridViewX1.Rows[index].Cells[2].Value = Npath;
                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText("添加异常" + ex.Message);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewX1.SelectedRows.Count == 0)
                {
                    Form msg = new Msg("请选择要取消监听的项");
                    msg.ShowDialog();
                }
                else if (dataGridViewX1.SelectedRows.Count > 1)
                {
                    Form msg = new Msg("只支持单次单个删除");
                    msg.ShowDialog();
                }
                else
                {
                    string Did = dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString();
                    if (File.Exists("config.xml"))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("config.xml");
                        XmlNodeList items = doc.SelectNodes("con/item");
                        for (int i = items.Count - 1; i >= 0; i--)
                        {
                            XmlNode item = items[i];
                            if (item.Attributes["id"].Value.ToString() == Did)
                            {
                                item.ParentNode.RemoveChild(item);
                            }
                        }
                        doc.Save("config.xml");
                        InitLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("删除异常---" + ex.Message);
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
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

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void hideMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MainFrn_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
    }
}
