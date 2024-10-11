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
    public class ProvidersLog
    {
        ProvidersDat objProv = new ProvidersDat();

        //Metodo para mostrar los Provedores
        public DataSet showProviders()
        {
            return objProv.showProviders();
        }

        //Metodo para guardar un nuevo Proveedor
        public bool saveProvider(string _nit, string _name)
        {
            return objProv.saveProvider(_nit,_name);
        }

        //Metodo para actualizar un Proveedor
        public bool updateProvider(int _id, string _nit, string _name)
        {
            return objProv.updateProvider(_id,_nit,_name);
        }
        //Metodo para borrar un Proveedor
        public bool deleteProvider(int _idProvider)
        {
            return objProv.deleteProvider(_idProvider);
        }
    }
}