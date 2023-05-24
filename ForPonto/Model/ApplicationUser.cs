using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ForPonto.Model
{
    public class ApplicationUser : IdentityUser
    {
        [JsonIgnore] public Ponto? Ponto { get; set; }
        [ForeignKey("Ponto")] public int? PontoId { get; set; }
        public int Salario { get; set; }

       // public int CargaHorariaSemanal { get;set; }
    }
} // para cada Ponto é um usuario

