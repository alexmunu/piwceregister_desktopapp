using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using PIWCeRegister.Source.Services;
using PIWCeRegister.Source.Models;

namespace PIWCeRegister
{

    internal class MemberViewModel:ViewModelBase
    {
        public MemberViewModel()
        {
            ListMembers = RestClientService.GetListMembers();
        }

        public List<member> ListMembers { get; set; }

        public member GetMemberById(int id)
        {
            return ListMembers.Find(x => x.Id == id);
        }

        public int GetMembersCount()
        {
           return ListMembers.Count;
        }

    }
}
