using FSI.SmartPark.Domain.ValueObjects;

namespace FSI.SmartPark.Domain.Entities.Operacional
{
    public class Veiculo : EntityBase
    {
        public Placa Placa { get; private set; }
        public string? Cor { get; private set; }
        public int? Ano { get; private set; }
        public int TipoVeiculo { get; private set; } // Sugestão: Futuramente usar um Enum
        public int? Modelo_Id { get; private set; }

        // Construtor vazio protegido: Necessário para o Dapper/Entity Framework
        protected Veiculo() { }

        // Construtor Principal: Garante que o Veículo nunca nasça sem Placa ou sem Tipo
        public Veiculo(string placa, int tipoVeiculo, int? modeloId = null)
        {
            // Calisthenics: O construtor da 'Placa' já faz o throw exception se for inválida
            // Isso remove a necessidade de "IFs" de validação de string aqui dentro.
            Placa = new Placa(placa);

            TipoVeiculo = tipoVeiculo;
            Modelo_Id = modeloId;
        }

        /// <summary>
        /// Método de negócio para atualização de dados complementares.
        /// Aplica a regra de que o Ano não pode ser maior que o ano atual + 1.
        /// </summary>
        public void AtualizarInformacoesAdicionais(string cor, int ano)
        {
            if (ano > DateTime.Now.Year + 1)
                throw new ArgumentException("O ano do veículo é inválido.");

            Cor = cor;
            Ano = ano;
        }

        /// <summary>
        /// Método para troca de modelo (caso tenha havido erro de cadastro)
        /// </summary>
        public void VincularModelo(int modeloId)
        {
            if (modeloId <= 0) throw new ArgumentException("Id do modelo inválido.");
            Modelo_Id = modeloId;
        }
    }
}