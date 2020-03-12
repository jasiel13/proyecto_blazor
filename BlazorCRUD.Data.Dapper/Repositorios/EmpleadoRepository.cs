using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositorios
{
    public class EmpleadoRepository : IEmpleadosRepository
    {
        //codigo para usar el empleadoservice
        private readonly EmpleadoService _empleadoService;

        public EmpleadoRepository(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        
        public Task<bool> DeleteEmpleado(string id)
        {
            throw new NotImplementedException();
        }
     
        public async Task<IEnumerable<Empleados>> GetAllEmpleados()
        {
            //throw new NotImplementedException(); 
            IEnumerable<Empleados> empleado = await GetAllEmpleados();
            _empleadoService.GetAllEmpleados();
            return empleado;

        }

        public Task<Empleados> GetEmpleadosDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertEmpleado(Empleados empleado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmpleado(Empleados empleado)
        {
            throw new NotImplementedException();
        }
    }
}
