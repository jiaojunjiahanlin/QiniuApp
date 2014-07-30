using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qiniu.RS;
using Qiniu.Conf;
using Qiniu.RSF;
using Qiniu.RPC;


namespace WindowsFormsApplication1
{
    public partial class Deletone : Form
    {
        public Deletone()
        {
            InitializeComponent();
            label3.Visible = false;
            label4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSClient client = new RSClient();
            CallRet ret = client.Delete(new EntryPath(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim()));
            if (ret.OK)
            {
                label3.Visible = true;
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label3.Visible = false;
            }
        }
    }
}
