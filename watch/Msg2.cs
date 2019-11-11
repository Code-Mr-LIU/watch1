using System;
using System.Windows.Forms;

namespace watch
{
    public partial class Msg2 : Form
    {
        public Msg2()
        {
            InitializeComponent();
        }
        public Msg2(string info)
        {
            InitializeComponent();
            labelX1.Text = info;
        }

        private void btnQX_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnQD_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
