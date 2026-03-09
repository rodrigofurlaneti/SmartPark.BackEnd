using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.SmartPark.Domain.Entities.Operacional
{
    public class Faturamento : EntityBase
    {
        public int NumFechamento { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime DataFechamento { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorDinheiro { get; private set; }
        public decimal ValorCartaoDebito { get; private set; }
        public decimal ValorCartaoCredito { get; private set; }
        public int Unidade_Id { get; private set; }

        public void FecharTurno(decimal total)
        {
            DataFechamento = DateTime.Now;
            ValorTotal = total;
        }
    }
}
