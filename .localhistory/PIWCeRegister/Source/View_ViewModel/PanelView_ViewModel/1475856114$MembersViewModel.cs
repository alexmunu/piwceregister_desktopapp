﻿using System;
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
        public MembersViewModel()
        {
            ListMembers = RestClientService.GetListMembers();
            var proto = new ProtobufContext(new piwcldbEntities());
            proto.Executor<member>();

            ListMembers = proto.Context<member>();
        }

        private List<member> ListMembers { get; set; }

        public member GetMemberById(int id)
        {
            var result = ListMembers.Where(member => member.Id == id);
            return result.ElementAt(0) ;
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
