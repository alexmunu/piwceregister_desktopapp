#region Documentation -----------------------------------------------------------------------------
// file:	Source\Services\ProtobufContext.cs
// Namespace:      PIWCeRegister.Source.Services
// Class:          ProtobufContext
// Author:         Alessandro Munufie                   
//
// summary	
//          The ProtobufContext class is a class that uses the protobuf-net library.
//          
//          (The Protobuf-net is a contract based serializer for .NET code, 
//          that happens to write data in the "protocol buffers" serialization 
//          format engineered by Google.)
//          
//           The purpose of this class is to serialise and then store in different files each entity present in a database.
//           It works in two different ways:
//           1) By receiving an instance of a DbContext inherited class (normally it should be created by using .Net Entity Framework Builder Tool)
//              it will dowload and store all the entities as explained above.
//           2) By defult which will initialise the class instace with a non null value.
//           
//           Either or not the connection to the database has been succesful, the classs will load the specified by type serialised/stored entity.    
//           
//          
// 
#endregion

using PIWCeRegister.Source.Models;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace PIWCeRegister.Source.Services
{
    class ProtobufContext
    {
        private readonly DbContext _dbContext;

        private readonly List<object> _modelsList;

        private readonly Dictionary<string, object> _properties;

        private ProtoContext _instance;

        public ProtobufContext(DbContext dbContext)
        {
            _dbContext = dbContext;
            this._modelsList = new List<object>();
            this._properties = new Dictionary<string, object>();
        }

        public ProtobufContext()
        {
            this._modelsList = new List<object>();
            this._properties = new Dictionary<string, object>();
        }

        private void Init<TModel>(List<TModel> modelList)
        {
            //var p = this._ as IDictionary<string, List<T>>;
            //p.Add(typeof(T).Name + "s",modelList);
            //var propertyName = typeof(T).Name + "s";
            _properties.Add(typeof(TModel).Name + "s", modelList);
            Collector();
        }

        private void Collector()
        {
            this._instance = new ProtoContext(_properties);
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

        private List<TModel> LoadSerialisedList<TModel>() where TModel : class, IModel
        {
            var p = new List<TModel>();

            using (var file = File.OpenRead((typeof(TModel).Name + "s.bin")))
            {
                p = Serializer.Deserialize<List<TModel>>(file);
            }

            return p;
        }

        private void SaveSerialisedList<T>(List<T> list) where T : class, IModel
        {
            using (var file = File.Create(typeof(T).Name + "s.bin"))
            {
                Serializer.Serialize(file, list);
            }
        }

        public List<object> ModelsList => _modelsList;

        public void Add<TModel>(TModel model) where TModel : class,IModel
        {
            if (_modelsList.Count > 0)
            {
                foreach (var modelList in _modelsList)
                {
                    var modelName = modelList.GetType().GetElementType().Name;

                    if (modelName == typeof(TModel).Name)
                    {
                        ((List<TModel>)modelList).Add(model);
                    }

                }
            }
            else
            {
                _modelsList.Add(new List<TModel> { model });
            }

        }

        public List<TModel> Context<TModel>() where TModel : class,IModel
        {
            return _instance.GetPropertyValue<TModel>(typeof(TModel).Name + "s");
        }

        
        public void Executor<TModel>() where TModel : class,IModel
        {
            var modelList = new List<TModel>();
            if (TestConnection)
            {
                modelList = _dbContext.Set<TModel>().ToList();
                //Save serialised Model List
                SaveSerialisedList(modelList);
            }
            else
            {
                try
                {
                    modelList = LoadSerialisedList<TModel>();
                }
                catch (Exception)
                {
                    modelList = null;
                }
            }

            Init(modelList);
            this._modelsList.Add(modelList);
        }
         
        public void ExecutorInterface<TModel>(object func) where TModel : class,IModel
        {
            Init(func as List<TModel>);
        }



    }
}
