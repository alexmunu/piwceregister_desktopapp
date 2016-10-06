using PIWCeRegister.Source.Models;
using ProtoBuf;
using System;
using System.CodeDom;
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

    class ProtobufContext : DynamicObject
    {
        private readonly DbContext _dbContext;

        private readonly List<Object> _modelsList;

        private readonly Dictionary<string, object> _properties;

        private ProtoContext instance;

        public List<object> ModelsList => _modelsList;

        public void Add<T>(T model)
        {
            if (_modelsList.Count > 0)
            {
                foreach (var modelList in _modelsList)
                {
                    var modelName = modelList.GetType().GetElementType().Name;

                    if (modelName == typeof(T).Name)
                    {
                        ((List<T>)modelList).Add(model);
                    }

                }
            }
            else
            {
                _modelsList.Add(new List<T> { model });
            }

        }


        public ProtobufContext()
        {
            this._modelsList = new List<object>();
            this._properties = new Dictionary<string, object>();
        }

        public ProtoContext Context => instance;

        private void Init<T>(List<T> modelList)
        {
            //var p = this._ as IDictionary<string, List<T>>;
            //p.Add(typeof(T).Name + "s",modelList);
            //var propertyName = typeof(T).Name + "s";
            _properties.Add(typeof(T).Name + "s", modelList);
            Collector();
        }

        private void Collector()
        {
            this.instance = new ProtoContext(_properties);
        }

        private bool TestConnection
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
                catch (Exception)
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
                try
                {
                    modelList = LoadSerialisedList<T>();
                }
                catch (Exception)
                {

                    modelList = null;
                }

            }

            Init(modelList);

            this._modelsList.Add(modelList);

        }


        public void ExecutorInterface<T>(List<T> func) where T : class
        {
            Init(func);

            this._modelsList.Add(func);
        }

        List<T> LoadSerialisedList<T>() where T : class
        {
            var p = new List<T>();

            using (var file = File.OpenRead((typeof(T).Name + "s.bin")))
            {
                p = Serializer.Deserialize<List<T>>(file);
            }

            return p;
        }

        void SaveSerialisedList<T>(List<T> list) where T : class
        {
            using (var file = File.Create(typeof(T).Name + "s.bin"))
            {
                Serializer.Serialize(file, list);
            }
        }


    }
}
