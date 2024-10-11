using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class UsersDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar todos los Usuarios
        public DataSet showUsers()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectUsers";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para guardar un nuevo Usuario
        public bool saveUsers(string _mail, string _password, string _salt, string _state, DateTime _date, int _fkrol, int _fkemployee)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertUsers"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_mail", MySqlDbType.VarString).Value = _mail;
            objSelectCmd.Parameters.Add("p_password", MySqlDbType.VarString).Value = _password;
            objSelectCmd.Parameters.Add("p_salt", MySqlDbType.VarString).Value = _salt;
            objSelectCmd.Parameters.Add("p_state", MySqlDbType.VarString).Value = _state;
            objSelectCmd.Parameters.Add("p_date", MySqlDbType.Date).Value = _date;
            objSelectCmd.Parameters.Add("p_rol", MySqlDbType.Int32).Value = _fkrol;
            objSelectCmd.Parameters.Add("p_employee", MySqlDbType.Int32).Value = _fkemployee;


            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        //Metodo para actualizar un Usuario
        public bool updateUsers(int _id, string _mail, string _password, string _salt, string _state, DateTime _date, int _fkrol, int _fkemployee)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateUsers"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("p_mail", MySqlDbType.VarString).Value = _mail;
            objSelectCmd.Parameters.Add("p_password", MySqlDbType.VarString).Value = _password;
            objSelectCmd.Parameters.Add("p_salt", MySqlDbType.VarString).Value = _salt;
            objSelectCmd.Parameters.Add("p_state", MySqlDbType.VarString).Value = _state;
            objSelectCmd.Parameters.Add("p_date", MySqlDbType.Date).Value = _date;
            objSelectCmd.Parameters.Add("p_rol", MySqlDbType.Int32).Value = _fkrol;
            objSelectCmd.Parameters.Add("p_employee", MySqlDbType.Int32).Value = _fkemployee;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}