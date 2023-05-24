using ForPonto.Model;

namespace ForPonto.Interface.Service
{
    public interface ISalarioService
    {
        Task<List<Salario>> ListarSalario();
        Task<Salario> ObterSalario(int id);
       // Task<int> AdicionarSalario(SalarioDto salarioDto);
       // Task<int> AtualizarSalario(int id, SalarioDto salarioDto);
    }
}