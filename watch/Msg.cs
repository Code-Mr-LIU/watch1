using System.Windows.Forms;
using System;

namespace watch
{
    public partial class Msg : Form
    {
        public Msg()
        {
            InitializeComponent();
        }

        public Msg(string info)
        {
            InitializeComponent();
            labelX1.Text = info;
        }

        private void btnQD_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
