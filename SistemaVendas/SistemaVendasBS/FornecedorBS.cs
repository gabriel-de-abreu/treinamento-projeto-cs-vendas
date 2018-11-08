﻿using SistemaVendasDAO.DAO;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaVendasBS
{
    public class FornecedorBS
    {
        public static Fornecedor Create(Fornecedor fornecedor)
        {
            return new FornecedorDAO().Create(fornecedor);
        }

        public static DataTable GetAll()
        {
            return new FornecedorDAO().GetAll();
        }
    }
}