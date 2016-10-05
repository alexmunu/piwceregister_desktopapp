using PIWCeRegister.Source.Models;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PIWCeRegister.Source.Services
{
    class ProtobufContext
    {
        private readonly DbContext dbContext;
        public ProtobufContext(DbContext dbContext)
        {
            this.dbContext = dbContext;
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

        List<T> GetList<T>() where T : class => dbContext.Set<T>().ToList();

        void Serialise<T>(List<T> list) where T : class
        {
            using (var file = File.Create(typeof(T).Name)) 
            {
                   Serializer.Serialize(file,list);
            }
        }
    }
}
