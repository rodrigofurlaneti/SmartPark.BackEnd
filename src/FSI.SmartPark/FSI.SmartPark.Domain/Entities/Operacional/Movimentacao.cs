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

        // [A07] Campos operacionais do PDV adicionados conforme modelagem MySQL
        public int? IdSoftpark { get; private set; }           // ID de integração com sistema legado
        public int NumFechamento { get; private set; }         // Número do fechamento de caixa
        public int NumTerminal { get; private set; }           // Terminal/caixa que registrou
        public DateTime DataAbertura { get; private set; }     // Abertura do turno
        public DateTime DataFechamento { get; private set; }   // Fechamento do turno
        public string? DescontoUtilizado { get; private set; } // Tipo de desconto aplicado
        public decimal ValorDesconto { get; private set; }     // Valor descontado
        public string? TipoCliente { get; private set; }       // Ex: "Rotativo", "Mensalista"
        public string? NumeroContrato { get; private set; }    // Contrato do mensalista (se aplicável)
        public bool VagaIsenta { get; private set; }           // Vaga sem cobrança
        public string? Cpf { get; private set; }               // CPF do cliente (emissão NF)
        public string? Rps { get; private set; }               // Recibo Provisório de Serviço (NF)
        public string? FormaPagamento { get; private set; }    // Meio de pagamento utilizado
        public int? Cliente_Id { get; private set; }           // Cliente vinculado (mensalista)

        public Movimentacao(string placa, int unidadeId)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("Placa é obrigatória.");

            Placa = placa.ToUpper().Replace("-", "");
            Unidade_Id = unidadeId;
            DataEntrada = DateTime.Now;
            DataAbertura = DateTime.Now;
            Ticket = Guid.NewGuid().ToString()[..8].ToUpper();
        }

        public void RegistrarSaida(decimal valor, string? formaPagamento = null)
        {
            if (DataSaida.HasValue)
                throw new InvalidOperationException("Veículo já registrou saída.");

            DataSaida = DateTime.Now;
            DataFechamento = DateTime.Now;
            ValorCobrado = valor;
            FormaPagamento = formaPagamento;
        }

        public void AplicarDesconto(string tipoDesconto, decimal valorDesconto)
        {
            DescontoUtilizado = tipoDesconto;
            ValorDesconto = valorDesconto;
        }

        public void VincularCliente(int clienteId, string? numeroContrato = null)
        {
            Cliente_Id = clienteId;
            NumeroContrato = numeroContrato;
            TipoCliente = numeroContrato is not null ? "Mensalista" : "Avulso";
        }

        public void InformarCpfParaNF(string cpf) => Cpf = cpf;
        public void MarcarVagaIsenta()             => VagaIsenta = true;
    }
}
