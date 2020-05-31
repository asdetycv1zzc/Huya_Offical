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
        private string JsonData;
        public struct LiveRoomInformation
        {
            public int Page;
            public int PageSize;
            public string[] DJName;
            public string[] RoomName;
            public string[] GameFullName;
            public int[] WatchingAmount;
            public string[] AvatarPictureAddress; //主播头像的照片流地址
            public string[] ScreenshotPictureAddress; //屏幕截图的照片流地址
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
        private int TotalPage()
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var TotalPage = Convert.ToInt32(rb.data.totalPage);
            return TotalPage;
        }
        private int Page()
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var Page = Convert.ToInt32(rb.data.page);
            return Page;
        }
        private int PageSize()
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var PageSize = Convert.ToInt32(rb.data.pageSize);
            return PageSize;
        }
        private string DJName(int Num)
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var DJName = rb.data.datas[Num].nick;
            return DJName;
        }
        private string RoomName(int Num)
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var RoomName = rb.data.datas[Num].roomName;
            return RoomName;
        }
        private string GameFullName(int Num)
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var GameFullName = rb.data.datas[Num].gameFullName;
            return GameFullName;
        }
        private int WatchingAmount(int Num)
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var WatchingAmount = Convert.ToInt32(rb.data.datas[Num].totalCount);
            return WatchingAmount;
        }
        private string AvatarPictureAddress(int Num)
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var AvatarPictureAddress = rb.data.datas[Num].avatar180;
            return AvatarPictureAddress;
        }
        private string ScreenshotPictureAddress(int Num)
        {
            Json.Json.RootObject rb = JsonConvert.DeserializeObject<Json.Json.RootObject>(JsonData);
            var ScreenshotPictureAddress = rb.data.datas[Num].screenshot;
            return ScreenshotPictureAddress;
        }
        public LiveRoomInformation PageInformation(int Page)
        {
            string[] DJNames = { "" };
            string[] RoomNames = { "" };
            string[] GameFullNames = { "" };
            int[] WatchingAmounts = { 0 };
            string[] AvatarPictureAddresses = { "" };
            string[] ScreenshotPictureAddresses = { "" };
            string HuyaAddress = "https://www.huya.com/cache.php?m=LiveList&do=getLiveListByPage&tagAll=0&page=" + Page.ToString();
            string HuyaHost = "www.huya.com";
            HttpGet.HttpGet.HttpRequestStruction httpRequestStruction = new HttpGet.HttpGet.HttpRequestStruction()
            {
                Uri = HuyaAddress,
                Method = "GET",
                Host = HuyaHost,
                Referer = HuyaHost,
                AcceptEncoding = "None"
            };

            JsonData = OriginJson(httpRequestStruction);
            var Size = PageSize();
            for(int i = 1; i <= Size;i++)
            {
                DJNames[i - 1] = DJName(i);
                RoomNames[i - 1] = RoomName(i);
                GameFullNames[i - 1] = GameFullName(i);
                WatchingAmounts[i - 1] = WatchingAmount(i);
                AvatarPictureAddresses[i - 1] = AvatarPictureAddress(i);
                ScreenshotPictureAddresses[i - 1] = ScreenshotPictureAddress(i);
            }
            LiveRoomInformation liveRoomInformation = new LiveRoomInformation()
            {
                Page = Page,
                PageSize = PageSize(),
                DJName = DJNames,
                RoomName = RoomNames,
                GameFullName = GameFullNames,
                WatchingAmount = WatchingAmounts,
                AvatarPictureAddress = AvatarPictureAddresses,
                ScreenshotPictureAddress = ScreenshotPictureAddresses
            };
            return liveRoomInformation;
        }
    }

}
