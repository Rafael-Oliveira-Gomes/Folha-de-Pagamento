namespace ForPonto.Model
{
    public class Ponto
    {
        public Ponto() { }
        public DateTime Dia { get; set; }
        public TimeSpan HorarioEntrada { get; set; }
        public TimeSpan? HorarioSaida { get; set; }
        public int? Id { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}

