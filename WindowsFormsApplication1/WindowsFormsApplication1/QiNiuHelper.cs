using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Qiniu.Auth.digest;
using Qiniu.RPC;
using Qiniu.RS;
using Qiniu.Util;
using Newtonsoft.Json;
using System.Web;
using System.Xml;


namespace Adf.GuangQuan.Service.QiNiu
{
    /// <summary>
    /// 七牛上传辅助类
    /// </summary>
    public class QiNiuHelper
    {
        public static String AccessKey = "dL3iWMKzQMTap8Puxi5XcUgqzuKjCukchqkXHcIR";
        public static String SecretKey = "fOW181hnBdkCOdM5Tpm7anPv0dwxDCvMuKIBVvk1";


        /// <summary>
        /// 默认地址
        /// </summary>
        public static String FormAction = "http://upload.qiniu.com/";

        #region 上传tolen设置

        /// <summary>
        /// 得到令牌
        /// </summary>
        /// <returns></returns>
        public static String GetToken()
        {
            String HLValue = "";
            //账号
            String bucket = "liuhanlin-work";
            PutPolicy curPutPolicy = new PutPolicy(bucket);
            curPutPolicy.Scope = bucket;
            System.Text.Encoding curEncoding = System.Text.Encoding.UTF8;

            Mac macInfo = new Mac(AccessKey, curEncoding.GetBytes(SecretKey));

            HLValue = curPutPolicy.Token(macInfo);

            return HLValue;
        }
        #endregion

        public static string Encode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";
            else
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).Replace('+', '-').Replace('/', '_');
        }

        public static string ToBase64URLSafe(string str)
        {
            return Base64URLSafe.Encode(str);
        }

        public static string Encode(byte[] bs)
        {
            if (bs == null || bs.Length == 0)
                return "";
            else
                return Convert.ToBase64String(bs).Replace('+', '-').Replace('/', '_');
        }

        public static string JsonEncode(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static T ToObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        

        /// <summary>
        /// 得到对图片处理的url
        /// 
        /// String downurl = "http://pixbox.qiniu.com/o_190xxxttddxxxx.jpg?imageMogr2/crop/!300x300";
        /// String saveurl = GetImageSaveUrl(downurl,"pixboxpublic","111.jpg");
        /// 
        /// </summary>
        /// <param name="downloadUrl">处理图片的url</param>
        /// <param name="newFileName">保存成新的文件名</param>
        /// <returns></returns>
        public static String GetImageSaveUrl1(String downloadUrl, String bucketName, String newFileName)
        {
            String newUrl = downloadUrl.Replace("http://", "");
            String curEntryUri = bucketName + ":" + newFileName;
            String curEncodeEntryUri = ToBase64URLSafe(curEntryUri);

            String curSignStr = newUrl + "|saveas/" + curEncodeEntryUri;
            System.Text.Encoding curEncoding = System.Text.Encoding.UTF8;

            Mac macInfo = new Mac(AccessKey,curEncoding.GetBytes(SecretKey));
            String curSign = macInfo.Sign(curEncoding.GetBytes(curSignStr));

            String rValue = downloadUrl + "|saveas/" + curEncodeEntryUri + "/sign/" + curSign;
            return System.Web.HttpUtility.UrlDecode(rValue,Encoding.UTF8);
        }
        public static String GetImageSaveUrl(String downloadUrl, String bucketName, String newFileName)
        {
            String newUrl = downloadUrl.Replace("http://", "");
            String curEntryUri = bucketName + ":" + newFileName;
            String curEncodeEntryUri = ToBase64URLSafe(curEntryUri);

            String curSignStr = newUrl + "|saveas/" + curEncodeEntryUri;
            System.Text.Encoding curEncoding = System.Text.Encoding.UTF8;

            Mac macInfo = new Mac(AccessKey, curEncoding.GetBytes(SecretKey));
            String curSign = macInfo.Sign(curEncoding.GetBytes(curSignStr));
           // String new1 = ToBase64URLSafe(curSign);

            String rValue = downloadUrl + "|saveas/" + curEncodeEntryUri + "/sign/" + curSign;
            return System.Web.HttpUtility.UrlDecode(rValue, Encoding.UTF8);
        }
        public static String GetImageSaveUrl2(String downloadUrl, String bucketName, String newFileName)
        {
            String newUrl = downloadUrl.Replace("http://", "");
            String curEntryUri = bucketName + ":" + newFileName;
            String curEncodeEntryUri = ToBase64URLSafe(curEntryUri);

            String curSignStr = downloadUrl + "|saveas/" + curEncodeEntryUri;
            System.Text.Encoding curEncoding = System.Text.Encoding.UTF8;

            Mac macInfo = new Mac();
            String curSign = macInfo.Sign(curEncoding.GetBytes(curSignStr));

            String rValue = downloadUrl + "|saveas/" + curEncodeEntryUri + "/token/" + curSign;
          
            return rValue;
        }

        //public static CallRet Get(string url)
        //{
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        request.Method = "GET";
        //        request.UserAgent = Conf.Config.USER_AGENT;
        //        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        //        {
        //            return HandleResult(response);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return new CallRet(HttpStatusCode.BadRequest, e);
        //    }
        //}

        public static CallRet Get(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = Qiniu.Conf.Config.USER_AGENT;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return HandleResult(response);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new CallRet(HttpStatusCode.BadRequest, e);
            }
        }
        public static string HttpGet(string url)
        {
            //1.HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            //2.WebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }
        public static void get(String url)
        {
            string U = "http://liuhanlin-work.qiniudn.com/-123456.jpg?imageMogr/auto-orient/thumbnail/!50x50r/gravity/center/crop/!50x50/quality/80/rotate/90|saveas/bGl1aGFubGluLXdvcms6YnVoYW8xMi5qcGc: /sign/dL3iWMKzQMTap8Puxi5XcUgqzuKjCukchqkXHcIR:90TdJEQsaXK6Ml7ziwey4uoftN4";

            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求
            request = (System.Net.HttpWebRequest)WebRequest.Create(U);
            //request.Method="get";
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            XmlTextReader Reader = new XmlTextReader(s);
            Reader.MoveToContent();
            string strValue = Reader.ReadInnerXml();
            strValue = strValue.Replace("&lt;", "<");
            strValue = strValue.Replace("&gt;", ">");
            Reader.Close();
        }
    
        public static string HttpPost(string url, string param, string value)
        {
            //1.HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", value);
            request.Host = "api.qiniu.com";
            //request.KeepAlive = true;
            //request.Credentials = CredentialCache.DefaultCredentials;

            using (Stream reqStream = request.GetRequestStream())
            {
                byte[] bs = Encoding.UTF8.GetBytes(param);
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }

            //2.WebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                return stream.ReadToEnd();
            }
        }

        public static HttpWebResponse CreateGetHttpResponse(string url)
        {
            HttpWebRequest request = null;
            request.UserAgent = Qiniu.Conf.Config.USER_AGENT;
            if (url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
               
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;    //http版本，默认是1.1,这里设置为1.0
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "GET";

            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout;
           
            return request.GetResponse() as HttpWebResponse;
        }
            

        public static CallRet HandleResult(HttpWebResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseStr = reader.ReadToEnd();
                return new CallRet(statusCode, responseStr);
            }
        }

        public static string MakeGetToken(string key, Func<string, string> MakeUrlByBaseUrl = null, string domain = "pixbox.qiniudn.com")
        {
            string baseUrl = GetPolicy.MakeBaseUrl(domain, key);
            if (MakeUrlByBaseUrl != null)
            {
                baseUrl = MakeUrlByBaseUrl(baseUrl);
            }
            return GetPolicy.MakeRequest(baseUrl);
        }




    }
}
