﻿using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interfaces
{
    public interface IEmpleadoService
    {
        //definir metodos(insert,update,delete)
        Task<IEnumerable<Empleados>> GetAllEmpleados();//mostrar todos
        Task<Empleados> GetEmpleadosDetails(string id);//mostrar uno en especifico
        Task<bool> InsertEmpleado(Empleados empleado);

        Task<bool> UpdateEmpleado(Empleados empleado);

        Task<bool> DeleteEmpleado(string id);
    }
}
