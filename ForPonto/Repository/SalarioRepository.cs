using ForPonto.Config.Context;
using ForPonto.Interface.Repository;
using ForPonto.Model;
using Microsoft.EntityFrameworkCore;

namespace ForPonto.Repository
{
    public class SalarioRepository : ISalarioRepository
    {
        private readonly MySqlContext _context;

        public SalarioRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<List<Salario>> ListarSalarios(string userId)
        {
            return await _context.Salario
                .Where(s => s.ApplicationUserId == userId)
                .OrderByDescending(s => s.Ano)
                .ThenByDescending(s => s.Mes)
                .ToListAsync();
        }

        public async Task<Salario> ObterSalario(int id)
        {
            return await _context.Salario.FindAsync(id);
        }

        public async Task<int> AdicionarSalario(Salario salario)
        {
            _context.Salario.Add(salario);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AtualizarSalario(Salario salario)
        {
            _context.Entry(salario).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoverSalario(int id)
        {
            Salario salario = await ObterSalario(id);
            if (salario != null)
            {
                _context.Salario.Remove(salario);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
