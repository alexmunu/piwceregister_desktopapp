using PIWCeRegister.Source.Models;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PIWCeRegister.Annotations;

namespace PIWCeRegister.Source.Services
{
          
    class ProtobufContext 
    {
        private readonly DbContext dbContext;

        private List<Object> modelsList;

        private dynamic protoContext;

        public ProtobufContext(DbContext dbContext)
        {
            this.dbContext = dbContext;
            protoContext=new ExpandoObject();
        }
                    
        public void Save()
        {
            foreach (var modelList in modelsList)
            {
                Serialise(modelsList);
            }
        }

        public void Load()
        {

        }

        void Init<T>(List<T> modelList)
        {
            var p = protoContext as IDictionary<string, List<T>>;
            
                protoContext[typeof(T).Name+"s"] = modelList;
            
        }

        bool TestConnection
        {
            get
            {
                try
                {
                    var connection = dbContext.Database.Connection;
                }
                catch (InvalidOperationException invalidOperation)
                {
                    return false;
                }
                return true;
            }
        }

        void executor<T>() where T : class
        {
            var modelList = dbContext.Set<T>().ToList();


            Init<T>(modelList);

            this.modelsList.Add(modelList);
            
        }

        void Serialise<T>(List<T> list) where T : class
        {
            using (var file = File.Create(typeof(T).Name)) 
            {
                   Serializer.Serialize(file,list);
            }
        }
    }
}
