using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System.Windows.Media;

namespace Huya_Offical.Classes.LiveRooms.Build
{
    public class LiveRooms
    {
        const double LEFT_MARGIN = 10;
        const double TOP_MARGIN = 35;
        const double FREESPACE = 10;
        const double HEIGHT = 190;
        const double WIDTH = 338;
        const string COLORARGB = "FF3F3F3F";
        const double CORNERRADIUS = 6.0;
        const double SPACING = 5.0;
        
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
            try
            {
                Get.Get get = new Get.Get();
                var LiveRoomInformation = get.PageInformation(1);//接口设计失误，先执行以获得总页数
                var TotalPages = LiveRoomInformation.TotalPage;
                var PageSize = LiveRoomInformation.PageSize;
                BrushConverter brushConverter = new BrushConverter();
                Brush brush = (Brush)brushConverter.ConvertFromString(COLORARGB);
                CornerRadius cornerRadius = new CornerRadius(CORNERRADIUS);
                //Brush brush = new SolidColorBrush(Color.FromArgb(1, 1, 1, 1));
                Pagination pagination = new Pagination()
                {
                    Height = 28,
                    HoverBrush = brush,
                    CornerRadius = cornerRadius,
                    Spacing = SPACING,
                    TotalIndex = TotalPages
                };
            }
            catch(Exception e)
            {
                MessageBox.Show("在构建分页时，遇到错误：" + e.Message);
                return null;
            }
            
        }
        private bool BuildPaginition()
        {
            try
            {
                Get.Get get = new Get.Get();
                var LiveRoomInformation = get.PageInformation(1);//接口设计失误，先执行以获得总页数
                var TotalPages = LiveRoomInformation.TotalPage;
                var PageSize = LiveRoomInformation.PageSize;
                BrushConverter brushConverter = new BrushConverter();
                Brush brush = (Brush)brushConverter.ConvertFromString(COLORARGB);
                CornerRadius cornerRadius = new CornerRadius(CORNERRADIUS);
                //Brush brush = new SolidColorBrush(Color.FromArgb(1, 1, 1, 1));
                Pagination pagination = new Pagination()
                {
                    Height = 28,
                    HoverBrush = brush,
                    CornerRadius = cornerRadius,
                    Spacing = SPACING,
                    TotalIndex = TotalPages
                };
            }
        }
    }
}
