using System.Collections.Generic;

namespace Huya_Offical.Classes.Json
{
    public class Json
    {
        public class ListPos1
        {
            public string sIcon { get; set; }
            public string sContent { get; set; }
        }

        public class Attribute
        {
            public ListPos1 ListPos1 { get; set; }
        }

        public class Datas
        {
            public string gameFullName { get; set; }
            public string gameHostName { get; set; }
            public string boxDataInfo { get; set; }
            public string totalCount { get; set; }
            public string roomName { get; set; }
            public string bussType { get; set; }
            public string screenshot { get; set; }
            public string privateHost { get; set; }
            public string nick { get; set; }
            public string avatar180 { get; set; }
            public string gid { get; set; }
            public string introduction { get; set; }
            public string recommendStatus { get; set; }
            public string recommendTagName { get; set; }
            public string isBluRay { get; set; }
            public string bluRayMBitRate { get; set; }
            public string screenType { get; set; }
            public string liveSourceType { get; set; }
            public string uid { get; set; }
            public string channel { get; set; }
            public string liveChannel { get; set; }
            public string imgRecInfo { get; set; }
            public string aliveNum { get; set; }
            public Attribute attribute { get; set; }
            public string profileRoom { get; set; }
            public string isRoomPay { get; set; }
            public string roomPayTag { get; set; }
        }

        public class Data
        {
            public string page { get; set; }
            public string pageSize { get; set; }
            public string totalPage { get; set; }
            public string totalCount { get; set; }
            public List<Datas> datas { get; set; }
            public string time { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }
    }
}
