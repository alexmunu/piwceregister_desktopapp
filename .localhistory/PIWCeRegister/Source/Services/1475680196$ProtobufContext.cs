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
                    
        
        private void Load()
        {

        }

        public ExpandoObject Context { get; }

        private void Init<T>(List<T> modelList)
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

        public void Executor<T>() where T : class
        {
            var modelList=new List<T>() ;
            if (TestConnection)
            {
                modelList = dbContext.Set<T>().ToList();
                //Save serialised Model List
                SaveSerialisedList(modelList); 
            }
            else
            {
                
            }    

            Init(modelList);

            this.modelsList.Add(modelList);
            
        }

        void SaveSerialisedList<T>(List<T> list) where T : class
        {
            using (var file = File.Create(typeof(T).Name+"s")) 
            {
                   Serializer.Serialize(file,list);
            }
        }
    }
}
