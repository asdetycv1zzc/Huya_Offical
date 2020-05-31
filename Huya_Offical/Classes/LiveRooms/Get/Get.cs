using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Huya_Offical.Classes.LiveRooms.Get
{
    public class Get
    {
        public struct LiveRoomInformation
        {
            public string DJName;
            public string RoomName;
            public string gameFullName;
            public long WatchingAmount;
            public Stream AvatarPictureStream; //主播头像的照片流
            public Stream ScreenshotPictureStream; //屏幕截图的照片流
        };
        public string OriginJson(HttpGet.HttpGet.HttpRequestStruction httpRequestStruction)
        {
            HttpGet.HttpGet httpGet = new HttpGet.HttpGet();
            var result = httpGet.Get(httpRequestStruction);
            try
            {
                Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(result);
                if (rb.status != "200")
                {
                    MessageBox.Show("虎牙服务器错误，代码：" + rb.status);
                    return null;
                }
            }
            catch(JsonSerializationException jse)
            {
                MessageBox.Show("在解析字符串：\n" + result + "是，遇到了：" + jse.Message + "错误！");
                return null;
            }
            catch(Exception e)
            {
                MessageBox.Show("遇到未知错误：" + e.Message);
                return null;
            }
            return result;
        }
        private string DJName(string JsonData,int Num)
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
        }

    }
}
