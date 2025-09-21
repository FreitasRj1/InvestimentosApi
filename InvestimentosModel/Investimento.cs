namespace InvestimentosModel
{
    public class Investimento
    {
        public int Id { get; set; }
        public string NomeAtivo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
        public int Quantidade { get; set; }
    }
}
