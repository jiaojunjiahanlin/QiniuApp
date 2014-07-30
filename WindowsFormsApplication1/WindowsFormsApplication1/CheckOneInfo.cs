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

namespace WindowsFormsApplication1
{
    public partial class CheckOneInfo : Form
    {
        public CheckOneInfo()
        {
            InitializeComponent();
        }
        

               /// <summary>
               /// 查看单个文件属性信息
               /// </summary>
              /// <param name="bucket">七牛云存储空间名</param>
             /// <param name="key">文件key</param>
             /// 

   

     private void button1_Click(object sender, EventArgs e)
     {
      
         RSClient client = new RSClient();
         Entry entry = client.Stat(new EntryPath(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim()));
         if (entry.OK)
         {
            
             label3.Text = "Hash: " + entry.Hash;
             label4.Text = "Fsize: " + entry.Fsize;
             label5.Text = "PutTime: " + entry.PutTime;
             label6.Text ="MimeType: " + entry.MimeType;
             label7.Text = "Customer: " + entry.Customer;
                   
         }
         else
         {
             Console.WriteLine("Failed to Stat");
         }

     }

    
    }
}
