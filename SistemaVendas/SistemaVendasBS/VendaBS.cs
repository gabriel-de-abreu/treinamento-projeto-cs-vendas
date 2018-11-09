using SistemaVendasDAO;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaVendasBS
{
    public class VendaBS
    {
        public static bool Venda(Venda venda, List<Itens> items)
        {
            try
            {
                float valorTotal = 0;
                foreach (var item in items)
                {
                    valorTotal += item.Valor;
                }
                venda.ValorTotal = valorTotal;
                var id = new VendaDAO().Create(venda).Id;
                foreach (var item in items)
                {
                    item.IdVenda = id;
                    new ItensDAO().Create(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        
        public static DataTable GetAll()
        {
            return new VendaDAO().GetAll();
        }
    }
}