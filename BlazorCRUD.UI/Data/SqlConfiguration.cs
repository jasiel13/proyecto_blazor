using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Data
{
    public class SqlConfiguration
    {
        //creamos un constructor que va a recibir como parametro el connectionstring
        public SqlConfiguration(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; }
    }
}
