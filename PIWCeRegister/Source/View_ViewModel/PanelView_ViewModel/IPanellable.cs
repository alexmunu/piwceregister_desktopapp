using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWCeRegister.Source.View_ViewModel.PanelView_ViewModel
{
    interface IPanellable
    {
        int GetModelListCount();

        string ModelName();
    }
}
