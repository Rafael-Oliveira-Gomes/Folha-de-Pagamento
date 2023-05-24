using ForPonto.Model;
using ForPonto.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForPonto.Interface.Service
{
    public interface IPontoService
    {
        Task<bool> RemoverPonto(int pontoId);
        Task<Ponto> GetPonto(int pontoId);
        Task<List<Ponto>> ListarPonto();
        Task<int> UpdatePonto(Ponto ponto);
        Task<bool> AdicionarPonto();
        Task<int> BaterPontoSaida(Ponto ultimoPonto);
        //Task<List<Ponto>> GetPontosByFuncionarioAndMonth(string userId, int year, int month);
        Task<List<Ponto>> ConsultarPontoToday();

    }
}
