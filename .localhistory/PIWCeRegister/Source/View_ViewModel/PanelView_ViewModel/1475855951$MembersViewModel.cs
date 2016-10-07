using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PIWCeRegister.Source.Models;
using PIWCeRegister.Source.Services;

namespace PIWCeRegister.Source.View_ViewModel.PanelView_ViewModel
{
    class MembersViewModel : IPanellable
    {
        private ProtobufContext _proto;

        public MembersViewModel()
        {
            ListMembers = RestClientService.GetListMembers();
            _proto = new ProtobufContext(new piwcldbEntities());
            _proto.Executor<member>();

            ListMembers = _proto.Context<member>();
        }

        private List<member> ListMembers { get; set; }

        public member GetMemberById(int id)
        {
            var result = ((member)(from member_ in ListMembers
                                   where member_.Id == id
                                   select member_));

            return result;
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
