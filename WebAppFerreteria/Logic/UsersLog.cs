using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class UsersLog
    {
        UsersDat objUse = new UsersDat();

        //Metodo para mostrar todos los Usuarios
        public DataSet showUsers()
        {
            return objUse.showUsers();
        }

        //Metodo para guardar un nuevo Usuario
        public bool saveUsers(string _mail, string _password, string _salt, string _state, DateTime _date, int _fkrol, int _fkemployee)
        {
            return objUse.saveUsers(_mail, _password, _salt, _state, _date, _fkrol, _fkemployee);
        }

        //Metodo para actualizar un Usuario
        public bool updateUsers(int _id, string _mail, string _password, string _salt, string _state, DateTime _date, int _fkrol, int _fkemployee)
        {
            return objUse.updateUsers(_id, _mail, _password, _salt, _state, _date, _fkrol, _fkemployee);
        }
    }
}