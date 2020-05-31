using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;

namespace Huya_Offical.Classes.HttpGet
{
    public class HttpGet
    {
        public struct HttpRequestStruction
        {
            public string Uri;
            public string Method;
            public string Host;
            public string Referer;
            public string AcceptEncoding;
        };
        public string Get(HttpRequestStruction httpRequestStruction)
        {
            StreamReader reader;
            //HttpRequestStruction httpRequestStruction = new HttpRequestStruction();
            HttpWebRequest req = WebRequest.CreateHttp(httpRequestStruction.Uri);
            req.Method = httpRequestStruction.Method;
            //req.Host = httpRequestStruction.Host;
            req.Referer = httpRequestStruction.Referer;
            req.Headers.Add(HttpRequestHeader.AcceptEncoding, httpRequestStruction.AcceptEncoding);
            req.Headers.Add(HttpRequestHeader.KeepAlive, "TRUE");
            try
            {
                var respoense = req.GetResponse() as HttpWebResponse;
                if (respoense.ContentEncoding == "gzip")
                {
                    reader = new StreamReader(new GZipStream(respoense.GetResponseStream(), CompressionMode.Decompress));
                }
                reader = new StreamReader(respoense.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (WebException e)
            {
                switch (e.Status)
                {
                    case WebExceptionStatus.Timeout:
                        MessageBox.Show("请求超时！");
                        return null;
                    default:
                        MessageBox.Show("在请求：" + httpRequestStruction.Uri + "时，出现了：" + e.Status.ToString() + "错误！");
                        return null;
                }
            }
        }
    }
}
