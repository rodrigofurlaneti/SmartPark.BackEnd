using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.SmartPark.Domain.Entities.Operacional
{
    public class Movimentacao : EntityBase
    {
        public string Ticket { get; private set; }
        public string Placa { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataSaida { get; private set; }
        public decimal ValorCobrado { get; private set; }
        public int Unidade_Id { get; private set; }
        public int? Usuario_Id { get; private set; }

        public Movimentacao(string placa, int unidadeId)
        {
            Placa = placa;
            Unidade_Id = unidadeId;
            DataEntrada = DateTime.Now;
            Ticket = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        public void RegistrarSaida(decimal valor)
        {
            if (DataSaida.HasValue) throw new Exception("Veículo já deu saída");
            DataSaida = DateTime.Now;
            ValorCobrado = valor;
        }
    }
}
