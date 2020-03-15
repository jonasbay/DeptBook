using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Globalization;

namespace TheDeptBook
{
    class DeptorValueColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int input = (int)value;

            if (input < 0)
                return new SolidColorBrush(Colors.Red);
            else
                return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
