using SistemaVendasDAO;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaVendasBS
{
    public class ProdutoBS
    {
        public static Produto Create(Produto produto)
        {
            return new ProdutoDAO().Create(produto);
        }

        public static Produto Read(int id)
        {
            return new ProdutoDAO().Read(id);
        }
        public static Produto Update(Produto produto)
        {
            return new ProdutoDAO().Update(produto);
        }
        public static DataTable getAll()
        {
            return new ProdutoDAO().GetAll();
        }
    }
}