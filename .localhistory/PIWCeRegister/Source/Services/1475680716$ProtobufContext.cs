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
        private readonly DbContext _dbContext;

        private readonly List<Object> _modelsList;

        private readonly dynamic _protoContext;

        public ProtobufContext(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._modelsList = new List<object>();
            this._protoContext = new ExpandoObject();
        }

        public ExpandoObject Context => _protoContext;

        private void Init<T>(List<T> modelList)
        {
            var p = _protoContext as IDictionary<string, List<T>>;
            _protoContext[typeof(T).Name + "s"] = modelList;
        }


        bool TestConnection
        {
            get
            {
                try
                {
                    var connection = _dbContext.Database.Connection;
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
            var modelList = new List<T>();
            if (TestConnection)
            {
                modelList = _dbContext.Set<T>().ToList();
                //Save serialised Model List
                SaveSerialisedList(modelList);
            }
            else
            {
                modelList = Load<T>();
            }

            Init(modelList);

            this._modelsList.Add(modelList);

        }

        private List<T> Load<T>() where T : class
        {
            
        }

        void SaveSerialisedList<T>(List<T> list) where T : class
        {
            using (var file = File.Create(typeof(T).Name + "s"))
            {
                Serializer.Serialize(file, list);
            }
        }
    }
}
