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
        public DependencyProperty _class;

        public EPanel()
        {
            InitializeComponent();
            _class = DependencyProperty.Register("Class", typeof(string), typeof(EPanel));
        }

        public Object ContextualClass
        {
            get { return contextualClassColor((string)GetValue(_class)); }
            set { SetValue(_class, (string)value); }
        }

        private Color contextualClassColor(string _class)
        {
            var color = new Color();
            switch (_class)
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
            }

            return color;
        }
    }
}
