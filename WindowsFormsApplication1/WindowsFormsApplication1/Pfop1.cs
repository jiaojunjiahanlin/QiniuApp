using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Qiniu.RPC;
using Qiniu.FileOp;
using Adf.GuangQuan.Service.QiNiu;
using System.Net;
using System.Web;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;



namespace WindowsFormsApplication1
{
    public partial class Pfop1 : Form
    {
        public Pfop1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //七牛服务端对图片进行处理
            String newDomain = "liuhanlin-work";
         //   String newKey = "xxxxccssss-1.jpg";
            String imageUrl = "http://liuhanlin-work.qiniudn.com/-123456.jpg";
            ImageMogrify target = new ImageMogrify
            {
                Thumbnail = "!50x50r",
                Gravity = "center",
                Rotate = 90,
                Crop = "!50x50",
                Quality = 80,
                AutoOrient = true
            };
            String tmpUrl = target.MakeRequest(imageUrl);

             

            String tmpDealUrl = QiNiuHelper.GetImageSaveUrl(tmpUrl, newDomain, "buhao12.jpg");

           // CallRet tmpCallRet = QiNiuHelper.Get(tmpDealUrl);

            QiNiuHelper.get(tmpDealUrl);

         // string tmpCallRet = QiNiuHelper.HttpGet(tmpDealUrl);
            int a;

        }
    }
}
