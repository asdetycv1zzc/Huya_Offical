using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Huya_Offical.Classes.LiveRooms.Build
{
    public class LiveRooms
    {
        const double LEFT_MARGIN = 10;
        const double TOP_MARGIN = 35;
        const double FREESPACE = 10;
        const double HEIGHT = 190;
        const double WIDTH = 338;
        //public struct BuildImagesInformation
        //{
            //public int HorizonLength;
            //public int UprightLength;
        //}
        //private Thickness CalculateMargins(BuildImagesInformation buildImagesInformation)
        //{
            //return null;
        //}
        private string GetLiveRoomInformation()
        {
            Get.Get get = new Get.Get();
            var LiveRoomInformation = get.PageInformation(1);//接口设计失误，先执行以获得总页数
            var TotalPages = LiveRoomInformation.TotalPage;
            var PageSize = LiveRoomInformation.PageSize;
            for(int i = 1;i <= TotalPages;i++)
            {

            }
        }
    }
}
