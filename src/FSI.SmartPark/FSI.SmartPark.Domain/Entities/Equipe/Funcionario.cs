using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSI.SmartPark.Domain.Entities.Equipe
{
    public class Funcionario : EntityBase
    {
        public string Codigo { get; private set; }
        public decimal Salario { get; private set; }
        public int Status { get; private set; } // Enum StatusFuncionario
        public int TipoEscala { get; private set; } // Enum TipoEscala
        public DateTime? DataAdmissao { get; private set; }
        public int Pessoa_Id { get; private set; }
        public int? Cargo_Id { get; private set; }
        public int? Unidade_Id { get; private set; }
        public int? Supervisor_Id { get; private set; }

        public Funcionario(int pessoaId, decimal salario)
        {
            if (salario < 0) throw new Exception("Salário negativo inválido");
            Pessoa_Id = pessoaId;
            Salario = salario;
            Status = 1; // Ativo
        }

        public void AlterarSalario(decimal novoValor) => Salario = novoValor;
    }
}
