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
    public partial class Moveone : Form
    {
        public Moveone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            Console.WriteLine("\n===> Move {0}:{1} To {2}:{3}",
                    textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim(), textBox3.Text.ToString().Trim(), textBox4.Text.ToString().Trim());
            RSClient client = new RSClient();
            new EntryPathPair(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim(), textBox3.Text.ToString().Trim(), textBox4.Text.ToString().Trim());
            CallRet ret = client.Move(new EntryPathPair(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim(), textBox3.Text.ToString().Trim(), textBox4.Text.ToString().Trim()));
            if (ret.OK)
            {
                label5.Visible=true;
            }
            else
            {
                label6.Visible = true;
            }
        }
    }
}
