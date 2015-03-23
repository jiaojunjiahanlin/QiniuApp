using System;
using Qiniu.RPC;
using  Qiniu.FileOp;
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
    class Pfop
    {
        //七牛服务端对图片进行处理
    String newDomain = "batchcopy";
    String newKey = "xxxxccssss-1.jpg";
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
    
    
    /**
     我原来的写法
     */
        public  void prop()
        {
            String tmpUrl = target.MakeRequest(imageUrl);

            String tmpDealUrl = QiNiuHelper.GetImageSaveUrl(tmpUrl, newDomain, "Ab005.jpg");

            CallRet tmpCallRet = QiNiuHelper.Get(tmpDealUrl);
        }
   
    }
}
