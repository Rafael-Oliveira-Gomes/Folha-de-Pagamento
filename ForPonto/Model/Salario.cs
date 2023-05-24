namespace ForPonto.Model
{
    public class Salario
    {
        public int? Id { get; set; }
        public decimal Valor { get; set; } // valor do salário
        public DateTime DataPagamento { get; set; } // data de pagamento do salário
        public int Mes { get; set; } // número do mês referente ao pagamento do salário (opcional)
        public int Ano { get; set; } // ano referente ao pagamento do salário (opcional)
        public string ApplicationUserId { get; set; } // identificador do usuário que recebeu o salário (opcional)
        public ApplicationUser ApplicationUser { get; set; } // usuário que recebeu o salário (opcional)
    }
    public class SalarioDto
    {
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
    }

}