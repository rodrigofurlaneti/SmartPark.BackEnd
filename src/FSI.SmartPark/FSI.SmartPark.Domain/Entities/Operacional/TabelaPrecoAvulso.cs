using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.SmartPark.Domain.Entities.Operacional
{
    public class TabelaPrecoAvulso : EntityBase
    {
        public string Nome { get; private set; }
        public int TempoToleranciaDesistencia { get; private set; }
        public int TempoToleranciaPagamento { get; private set; }
        public decimal ValorHoraAdicional { get; private set; }
        public bool Padrao { get; private set; }

        public TabelaPrecoAvulso(string nome, decimal valorAdicional)
        {
            Nome = nome;
            ValorHoraAdicional = valorAdicional;
        }
    }
}
