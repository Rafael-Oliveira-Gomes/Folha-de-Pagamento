using ForPonto.Config.Context;
using ForPonto.Interface.Repository;
using ForPonto.Model;
using Microsoft.EntityFrameworkCore;

namespace ForPonto.Repository
{
    public class PontoRepository : IPontoRepository
    {
        private readonly MySqlContext _context;

        public PontoRepository(MySqlContext context)
        {
            _context = context;
        }
        public async Task<Ponto> CreatePonto(Ponto ponto)
        {
            var ret = await _context.Ponto.AddAsync(ponto);

            await _context.SaveChangesAsync();

            ret.State = EntityState.Detached;

            return ret.Entity;
        }

        public async Task<bool> DeletePontoAsync(int Id)
        {
            var item = await _context.Ponto.FindAsync(Id);
            _context.Ponto.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }

        public Task<Ponto> GetPontoById(int IdUser)
        {
            throw new NotImplementedException();
        }

        public Task<Ponto> GetPontoByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ponto>> GetPontosByFuncionarioAndMonth(string userId, int month, int year)
        {
            var pontos = await _context.Ponto
                .Where(p => p.ApplicationUserId.Equals(userId) && p.Dia.Month == month && p.Dia.Year == year)
                .OrderBy(p => p.Dia)
                .ToListAsync();

            return pontos;
        }

        public async Task<Ponto> GetUltimoPontoByUserAndDay(string userId, DateTime dia)
        {
            var entity = await _context.Ponto
                .FirstOrDefaultAsync(p => p.ApplicationUserId.Equals(userId) && p.Dia.Equals(dia));
            return entity;
        }


        public async Task<List<Ponto>> ListDados()
        {
            List<Ponto> list = await _context.Ponto.OrderBy(p => p.Id).ToListAsync();
            return list;
        }

        public async Task<int> UpdatePonto(Ponto user)
        {
            _context.Entry(user).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }
    }
}


