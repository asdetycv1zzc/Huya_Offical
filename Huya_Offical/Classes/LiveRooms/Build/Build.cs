using System;
using System.Net.Cache;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Huya_Offical.Classes.LiveRooms.Build
{
    public class Build
    {
        private struct ImageStruction
        {
            public string Name;
            public double Height;
            public double Width;
            public Thickness Margin;
            public string Source;
        }
        private bool BuildOnlinePic(ImageStruction imageStruction)
        {
            try
            {
                Image image = new Image()
                {
                    Name = imageStruction.Name,
                    Height = imageStruction.Height,
                    Width = imageStruction.Width,
                    Margin = imageStruction.Margin,
                    Source = new BitmapImage(new Uri(imageStruction.Source), new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore))
                };
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("在构建" + imageStruction.Name + "时，遇到了错误：" + e.Message);
                return false;
            }
        }
    }
}
