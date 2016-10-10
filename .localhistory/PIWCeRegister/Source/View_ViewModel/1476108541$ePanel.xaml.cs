using System;
using System.Collections.Generic;
using System.Linq;
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
            set { SetValue(_class, ContextualClassColor(value)); }
        }
      
        private Color ContextualClassColor(object _class)
        {
            var color = new Color();
            switch ((string)_class)
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
                default :
                    color = (Color)_class; break;
            }

            return (color);
        }

    }
}
