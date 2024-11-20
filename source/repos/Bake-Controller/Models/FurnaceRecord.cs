namespace Bake_Controller.Models
{
    public class FurnaceRecord
    {
        public int Id { get; set; }
        public string? PlacaId { get; set; }
        public string? Cliente { get; set; }
        public DateTime HoraInicio { get; set; }
        public string? Usuario { get; set; }
        public int Matricula { get; set; }
        public string? Email { get; set; }
        public DateTime? HoraFim { get; set; }
        public string? LoginRetirada { get; set; }
        public string? Turno { get; set; }  // Adicionado Turno

        public string CalcularTurno(DateTime horaInicio)
        {
            var hora = horaInicio.TimeOfDay;

            if (hora >= TimeSpan.FromHours(6) && hora < TimeSpan.FromHours(14))
                return "Turno A";
            else if (hora >= TimeSpan.FromHours(14) && hora < TimeSpan.FromHours(22))
                return "Turno B";
            else
                return "Turno C";
        }
    }
}