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
            _class=DependencyProperty.Register("Class",typeof(string),typeof(EPanel));
        }

        public Color Class
        {
            get { return  (Color)GetValue(_class); }
            set { SetValue(_class,value); }
        }

        private ContextualClass(string _class)
        {
            Color color;
            switch (_class)
            {
                case "Primary":
                    color= Color.FromRgb(51,122,183);
                    break;
                case "Default":
                    color = Color.FromRgb(245, 245, 245);
                    break;
                case "Default":
                    color = Color.FromRgb(245, 245, 245);
                    break;
                case "Default":
                    color = Color.FromRgb(245, 245, 245);
                    break;

            }
        }
    }
}
