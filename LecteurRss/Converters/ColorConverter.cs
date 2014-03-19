using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LecteurRss.IHM.Converters
{
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            const string video = "Vidéo";

            if (value is string)
            {
                string chaine = value.ToString();

                if (chaine.ToLower().Contains(video.ToLower()))
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else
                {
                    return new SolidColorBrush(Colors.Black);
                }
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
