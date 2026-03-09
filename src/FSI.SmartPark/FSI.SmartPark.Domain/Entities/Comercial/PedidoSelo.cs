using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.SmartPark.Domain.Entities.Comercial
{
    public class PedidoSelo : EntityBase
    {
        public int Quantidade { get; private set; }
        public int StatusPedido { get; private set; } // Usar seu Enum StatusPedido
        public int Cliente_Id { get; private set; }
        public int Unidade_Id { get; private set; }

        public PedidoSelo(int quantidade, int clienteId, int unidadeId)
        {
            if (quantidade <= 0) throw new Exception("Quantidade mínima de 1 selo");
            Quantidade = quantidade;
            Cliente_Id = clienteId;
            Unidade_Id = unidadeId;
            StatusPedido = 1; // Pendente
        }
    }
}
