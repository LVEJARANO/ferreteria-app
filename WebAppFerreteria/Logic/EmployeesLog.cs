using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class EmployeesLog
    {
        EmployeesDat objEmp = new EmployeesDat();

        //Metodo para mostrar unicamente el id y el nombre de los Empleados, en el DropDownList
        public DataSet showEmployeesDDL()
        {
            return objEmp.showEmployeesDDL();
        }
    }
}