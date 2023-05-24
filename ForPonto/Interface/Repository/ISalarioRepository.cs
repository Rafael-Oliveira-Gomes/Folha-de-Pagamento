using ForPonto.Model;

namespace ForPonto.Interface.Repository
{
    public interface ISalarioRepository
    {
        Task<List<Salario>> ListarSalarios(string userId);
        Task<Salario> ObterSalario(int id);
        Task<int> AdicionarSalario(Salario salario);
        Task<int> AtualizarSalario(Salario salario);
        Task<bool> RemoverSalario(int id);
    }
}
