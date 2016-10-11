using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PIWCeRegister.Source.Models;
using PIWCeRegister.Source.Services;


namespace PIWCeRegister.Source.View_ViewModel
{
    class MembersViewModel : IPanellable
    {
        public MembersViewModel()
        {
            ListMembers = RestClientService.GetListMembers();
            var proto = new ProtobufContext(new piwcldbEntities());
            proto.Executor<member>();

            ListMembers = proto.Context<member>();
        }

        private IEnumerable<member> ListMembers { get; set; }

        public member GetMemberById(int id)
        {
            return ListMembers.Where(member => member.Id == id).ElementAt(0) ;
        }

         public IEnumerable<member> SearchInMembers(string key)
        {
            return ListMembers.Where(
                listMembers =>
                    listMembers.LastName.Contains(key) || listMembers.FirstName.Contains(key) ||
                    listMembers.Pim_no.Contains(key));
        }                              

        public string ModelName()
        {
            return TypeDescriptor.GetClassName(typeof(member));
        }

        public Color BackgroudColor() { return Color.FromRgb(26, 254, 244); }


        public ImageBrush panelImage()
        {
            return null;
        }

        public override string GetModelListCount
        {
            get
            {
                return "" +((List<member>)ListMembers).Count;
            }
        }
    }
}
