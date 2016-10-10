using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PIWCeRegister.Source.View_ViewModel
{
    public interface IPanellable
    {
        string GetModelListCount
        {
            get;
        }

        string ModelName();

        Color BackgroudColor();

        ImageBrush panelImage();

    }
}
