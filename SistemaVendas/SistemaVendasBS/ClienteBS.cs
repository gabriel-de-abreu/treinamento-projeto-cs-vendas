using SistemaVendasDAO.DAO;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaVendasBS
{
    public class ClienteBS
    {
        public static Cliente Create(Cliente cliente)
        {
            return new ClienteDAO().Create(cliente);
        }

        public static Cliente Read(int id)
        {
            return new ClienteDAO().Read(id);
        }

        public static Cliente Update(Cliente cliente)
        {
            return new ClienteDAO().Update(cliente);
        }

        public static Cliente Delete(Cliente cliente)
        {
            return new ClienteDAO().Delete(cliente);
        }

        public static DataTable GetAll()
        {
            return new ClienteDAO().GetAll();
        }
    }
}