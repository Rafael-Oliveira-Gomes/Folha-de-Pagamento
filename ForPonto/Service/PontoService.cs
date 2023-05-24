using ForPonto.Interface.Repository;
using ForPonto.Interface.Service;
using ForPonto.Model;
using ForPonto.Model.Dto;
using Lombok.NET.Analyzers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Data.Entity.Core;

namespace ForPonto.Service
{
    public class PontoService : IPontoService
    {
        private readonly IPontoRepository _pontoRepository;
        private readonly IAuthService _authService;

        public PontoService(IPontoRepository pontoRepository, IAuthService authService)
        {
            _pontoRepository = pontoRepository;
            _authService = authService;
        }

        public async Task<Ponto> GetPonto(int pontoId)
        {
            Ponto? ponto = await _pontoRepository.GetPontoById(pontoId);
            if (ponto == null) throw new ObjectNotFoundException("Não encontrou");

            return ponto;
        }

        public async Task<List<Ponto>> ListarPonto()
        {
            var ponto = await _pontoRepository.ListDados();

            return ponto;
        }

        public async Task<bool> RemoverPonto(int pontoId)
        {
            await _pontoRepository.GetPontoById(pontoId);
            return true;
        }

        public async Task<int> UpdatePonto(Ponto ponto)
        {

            ApplicationUser currentUser = await _authService.GetCurrentUser();

            return await _pontoRepository.UpdatePonto(ponto);
        }

        public async Task BaterPontoEntrada(string userId)
        {
            Ponto novoPonto = new Ponto
            {
                Dia = DateTime.Today,
                HorarioEntrada = DateTime.Now.TimeOfDay,
                ApplicationUserId = userId
            };
            await _pontoRepository.CreatePonto(novoPonto);
        }

        public async Task<int> BaterPontoSaida(Ponto ultimoPonto)
        {
            ultimoPonto.HorarioSaida = DateTime.Now.TimeOfDay;
            return await _pontoRepository.UpdatePonto(ultimoPonto);
        }

        public async Task<bool> AdicionarPonto()
        {
            try
            {
                // Obtém o usuário atual
                ApplicationUser currentUser = await _authService.GetCurrentUser();

                // Obtém o último ponto do usuário no dia atual
                Ponto ultimoPonto = await _pontoRepository.GetUltimoPontoByUserAndDay(currentUser.Id, DateTime.Today);

                // Verifica se já existe um registro de entrada para o dia atual
                //carma ae vou ligar pro cara pode mexer

                if (ultimoPonto == null)
                {
                    // Se não existe registro de entrada, cria um novo ponto com o horário de entrada
                    await BaterPontoEntrada(currentUser.Id);
                }
                else if (ultimoPonto.HorarioSaida == null)
                {
                    // Se já existe um registro de entrada sem o horário de saída preenchido, atualiza o horário de saída
                    await BaterPontoSaida(ultimoPonto);
                }
                else
                {
                    throw new Exception("Erro ao bater o ponto. Já bateu ponto de entrada e de saída hoje.");
                }

            }
            catch (Exception)
            {
                throw;
            }


            return true;
        }
        public async Task<List<Ponto>> ConsultarPontoToday()
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();
            Ponto ultimoPonto = await _pontoRepository.GetUltimoPontoByUserAndDay(currentUser.Id, DateTime.Today);

            if (ultimoPonto == null)
            {
                throw new Exception("Usuário ainda não bateu o ponto hoje.");
            }

           return new List<Ponto> { ultimoPonto };
        }
    }
}