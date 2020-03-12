using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.Data;
using BlazorCRUD.Model;

namespace BlazorCRUD.Data.Dapper.Repositorios
{
    public class EmpleadoService
    {
        //obteniendo la conexion por medio de la clase ArchivosDBMDatabaseSettings
        private readonly IMongoCollection<Empleados> _empleados;

        public EmpleadoService(IArchivosDBMDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _empleados = database.GetCollection<Empleados>(settings.EmpleadosPCollectionName);
        }

        public List<Empleados> GetAllEmpleados() =>
           _empleados.Find(empleado => true).ToList();

        public Empleados GetEmpleadosDetails(string id) =>
            _empleados.Find<Empleados>(empleado => empleado.Id == id).FirstOrDefault();

        public Empleados InsertEmpleado(Empleados empleado)
        {
            _empleados.InsertOne(empleado);
            return empleado;
        }
        public void UpdateEmpleado(Empleados empleado)
        {
            _empleados.ReplaceOne(filter: e => e.Id == empleado.Id, replacement: empleado);
        }

        /*public void UpdateEmpleado(string id, Empleados empleadosx) =>
        _empleados.ReplaceOne(empleado => empleado.Id == id, empleadosx);*/
        public void DeleteEmpleado(string id) =>
        _empleados.DeleteOne(empleado => empleado.Id == id);
    }
}
