using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PIWCeRegister.Source.View_ViewModel
{
    /// <summary>
    /// Interaction logic for ePanel.xaml
    /// </summary>
    public partial class EPanel : UserControl
    {
        public static readonly DependencyProperty _class = DependencyProperty.Register("ContextualClass", typeof(string), typeof(EPanel));

        public EPanel()
        {
            InitializeComponent();
              DataContext=new MembersViewModel();
        }

        public Object ContextualClass
        {
            get { return GetValue(_class); }
            set { SetValue(_class, value); }
        }
    }

    public class ClassColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                var val = value as string;
                Color c;
                if (val.StartsWith("#"))
                {
                    val = val.Replace("#", "");
                    byte a = System.Convert.ToByte("ff", 16);
                    byte pos = 0;
                    if (val.Length == 8)
                    {
                        a = System.Convert.ToByte(val.Substring(pos, 2), 16);
                        pos = 2;
                    }
                    byte r = System.Convert.ToByte(val.Substring(pos, 2), 16);
                    pos += 2;
                    byte g = System.Convert.ToByte(val.Substring(pos, 2), 16);
                    pos += 2;
                    byte b = System.Convert.ToByte(val.Substring(pos, 2), 16);
                    c = Color.FromArgb(a, r, g, b);
                    return new SolidColorBrush(c);
                }
                try
                {
                    c = GetColorFromString(value as string);
                    return new SolidColorBrush(c);
                }
                catch (InvalidCastException ex)
                {
                    return null;
                }
            }
            return null;
        }

        public static Color GetColorFromString(string colorString)
        {
            
            Color color;
            switch ((string)colorString)
            {
                case "Primary":

                    color = Color.FromRgb(51, 122, 183);
                    break;
                case "Default":
                    color = Color.FromRgb(255, 255, 255);
                    break;
                case "Info":
                    color = Color.FromRgb(91, 192, 222);
                    break;
                case "Warning":
                    color = Color.FromRgb(240, 173, 78);
                    break;
                case "Danger":
                    color = Color.FromRgb(217, 83, 79);
                    break;
                case "Succes":
                    color = Color.FromRgb(92, 184, 92);
                    break;
                default:
                    color = Colors.Azure; break;
            }
            
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush val = value as SolidColorBrush;
            return val.Color.ToString();
            //if (typeof(Colors).GetProperty(val.Color.ToString()) != null)
            //    return typeof(Colors).GetProperty(val.Color.ToString()).GetValue(val, null);
            //else
            //    return "#" + val.Color.A.ToString() + val.Color.R.ToString() + val.Color.G.ToString() + val.Color.B.ToString();
        }
    }
}
