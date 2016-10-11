using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PIWCeRegister.Source.View_ViewModel
{
    public abstract class IPanellable
    {
        public abstract string GetModelListCount
        {
            get;
        }

        protected abstract string ModelName();

        protected abstract Color BackgroudColor();

        protected abstract ImageBrush panelImage();
    }
}
