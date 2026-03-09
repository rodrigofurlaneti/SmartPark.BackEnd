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

        // [A08] Campos de fechamento de caixa adicionados conforme modelagem MySQL
        public int? IdSoftpark { get; private set; }                      // ID de integração legado
        public string? NomeUnidade { get; private set; }                  // Snapshot do nome (histórico)
        public int NumTerminal { get; private set; }                      // Terminal/caixa
        public string? TicketInicial { get; private set; }                // Primeiro ticket do turno
        public string? TicketFinal { get; private set; }                  // Último ticket do turno
        public string? PatioAtual { get; private set; }                   // Ocupação atual do pátio
        public decimal? ValorRotativo { get; private set; }               // Receita de clientes avulsos
        public decimal? ValorRecebimentoMensalidade { get; private set; } // Recebimentos de mensalistas
        public decimal? ValorSemParar { get; private set; }               // Receita via Sem Parar/Veloe
        public decimal? ValorSeloDesconto { get; private set; }           // Descontos via selos
        public decimal? SaldoInicial { get; private set; }                // Fundo de troco inicial
        public decimal? ValorSangria { get; private set; }                // Retirada de caixa no turno
        public int? Usuario_Id { get; private set; }                      // Operador responsável

        public Faturamento(int numFechamento, int numTerminal, int unidadeId, int usuarioId)
        {
            NumFechamento = numFechamento;
            NumTerminal = numTerminal;
            Unidade_Id = unidadeId;
            Usuario_Id = usuarioId;
            DataAbertura = DateTime.Now;
        }

        public void FecharTurno(
            decimal valorTotal,
            decimal dinheiro,
            decimal cartaoDebito,
            decimal cartaoCredito,
            decimal? valorRotativo = null,
            decimal? valorMensalidade = null,
            decimal? valorSemParar = null,
            decimal? valorSeloDesconto = null,
            string? ticketFinal = null)
        {
            DataFechamento = DateTime.Now;
            ValorTotal = valorTotal;
            ValorDinheiro = dinheiro;
            ValorCartaoDebito = cartaoDebito;
            ValorCartaoCredito = cartaoCredito;
            ValorRotativo = valorRotativo;
            ValorRecebimentoMensalidade = valorMensalidade;
            ValorSemParar = valorSemParar;
            ValorSeloDesconto = valorSeloDesconto;
            TicketFinal = ticketFinal;
        }

        public void DefinirSaldoInicial(decimal saldo) => SaldoInicial = saldo;
        public void RegistrarSangria(decimal valor)    => ValorSangria = (ValorSangria ?? 0) + valor;
        public void DefinirTicketInicial(string ticket) => TicketInicial = ticket;
    }
}
