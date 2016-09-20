using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIWCeRegister.Source.Models;
using RestSharp;

namespace PIWCeRegister.Source.Services
{
    public class RestClientService
    {
        private const string Url = "http://192.168.1.4:3000";
        private static RestClient _client = null;
        private static RestRequest _request = null;

        private static void ClientInstance()
        {
            if (_client != null) return;
            _client = new RestClient(Url);
        }

        public static List<member> GetListMembers()
        {
            ClientInstance();
            _request = new RestRequest("/ch_membersBD", Method.GET);
            var response2 = (RestResponse<List<member>>)_client.Execute<List<member>>(_request);
            return response2.Data;
        }
        
    }
}



