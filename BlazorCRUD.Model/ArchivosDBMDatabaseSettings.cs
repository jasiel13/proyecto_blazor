using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCRUD.Model
{
    //La BookstoreDatabaseSettings clase se utiliza para almacenar los valores de BookstoreDatabaseSettings propiedad del archivo appsettings.json
    public class ArchivosDBMDatabaseSettings : IArchivosDBMDatabaseSettings
    {
        public string EmpleadosPCollectionName { get; set; }
        public string FilesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }        
    }

    public interface IArchivosDBMDatabaseSettings
    {
        string EmpleadosPCollectionName { get; set; }
        string FilesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
