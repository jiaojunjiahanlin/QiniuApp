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

namespace WindowsFormsApplication1
{
    public partial class download : Form
    {
        public download()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = MakeGetToken(textBox1.Text, textBox2.Text);
        }

        public static string  MakeGetToken(string domain, string key)
        {
            string baseUrl = GetPolicy.MakeBaseUrl(domain, key);
            string private_url = GetPolicy.MakeRequest(baseUrl);
            return private_url;
        }
    }
}
