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
    public partial class CopyOneFile : Form
    {
        public CopyOneFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSClient client = new RSClient();
           CallRet ret = client.Copy(new EntryPathPair(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim(), textBox3.Text.ToString().Trim(), textBox4.Text.ToString().Trim()));
            if (ret.OK)
            {
                Console.WriteLine("Copy OK");
            }
            else
            {
                Console.WriteLine("Failed to Copy");
            }
        }
    }
}
