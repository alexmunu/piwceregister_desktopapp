using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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


    }
}
