using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIWCeRegister.Source.Models;
using PIWCeRegister.Source.Services;

namespace PIWCeRegister.Source.View_ViewModel.PanelView_ViewModel
{
    class MembersViewModel:IPanellable
    {
        public MembersViewModel()
        {
            ListMembers = RestClientService.GetListMembers();
        }

        private List<member> ListMembers { get; set; }

        public member GetMemberById(int id)
        {
            return ListMembers.Find(x => x.Id == id);
        }

        public int GetModelListCount()
        {
            return ListMembers.Count;
        }

        public string ModelName()
        {
            return TypeDescriptor.GetClassName(typeof(member));
        }
    }
}
