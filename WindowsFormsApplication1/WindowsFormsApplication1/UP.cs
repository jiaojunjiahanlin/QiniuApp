using Qiniu.IO;
using Qiniu.IO.Resumable;
using Qiniu.RPC;
using Qiniu.RS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UP : Form
    {
        //public event EventHandler<PutNotifyEvent> Notify1;
        //public event EventHandler<PutNotifyErrorEvent> NotifyErr1;
        public UP()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // PutFile("liuhanlin-work", "yinji", "F:\\迅雷下载\\郭敬明 陈砺志 李力《乱入小时代》_高清.mp4");
            ResumablePutFile("liuhanlin-work", "yinjinjing", "F:\\迅雷下载\\郭敬明 陈砺志 李力《乱入小时代》_高清.mp4");
        }
        public static void PutFile(string bucket, string key, string fname)
        {
            var policy = new PutPolicy(bucket, 3600);
            System.Console.WriteLine(policy);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
           PutRet ret= client.PutFile(upToken, key, fname, extra);
           ret.Response.ToString();
        }
        public static void ResumablePutFile(string bucket, string key, string fname)
        {
            Console.WriteLine("\n===> ResumablePutFile {0}:{1} fname:{2}", bucket, key, fname);
            PutPolicy policy = new PutPolicy(bucket, 3600);
            string upToken = policy.Token();
            Settings setting = new Settings();
            ResumablePutExtra extra = new ResumablePutExtra();
           // extra.Notify += new EventHandler<PutNotifyEvent>(extra_Notify);
          //  extra.NotifyErr += new EventHandler<PutNotifyErrorEvent>(extra_NotifyErr);
            ResumablePut client = new ResumablePut(setting, extra);
           // CallRet ret = client.PutFile(upToken, fname, Guid.NewGuid().ToString());
            CallRet ret = client.PutFile(upToken, fname, key);
            if (ret.OK)
            {
                MessageBox.Show("ok");
                MessageBox.Show(ret.Response);
                
            }
            else
            {
                MessageBox.Show(ret.Response);
            }
            

        }

        private static void extra_Notify(object sender, PutNotifyEvent e)
        {
            e.BlkIdx.ToString();
            e.BlkSize.ToString();
          //  e.Ret.offset.ToString();
            //2015年三月23日，提交了
            
          
        }

        private static void extra_NotifyErr(object sender, PutNotifyErrorEvent e)
        {
            
        }

        private void UP_Load(object sender, EventArgs e)
        {

        }

       
        
     
    }
}
