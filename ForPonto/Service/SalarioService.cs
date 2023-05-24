//using ForPonto.Interface.Repository;
//using ForPonto.Interface.Service;
//using ForPonto.Model;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace ForPonto.Services
//{
//    public class SalarioService : ISalarioService
//    {
//        private readonly ISalarioRepository _salarioRepository;

//        public SalarioService(ISalarioRepository salarioRepository)
//        {
//            _salarioRepository = salarioRepository;
//        }

//        public async Task<int> AdicionarSalario(SalarioDto salarioDto)
//        {
//            // Converte o DTO para a entidade de domínio
//            var salario = new Salario
//            {
//                Valor = salarioDto.Valor,
//                DataPagamento = salarioDto.DataPagamento
//            };

//            // Adiciona o salário ao repositório e retorna o id do novo registro
//            return await _salarioRepository.AdicionarSalario(salario);
//        }

//        public async Task<int> AtualizarSalario(int id, SalarioDto salarioDto)
//        {
//            // Verifica se o salário existe
//            var salarioExistente = await ObterSalario(id);
//            if (salarioExistente == null)
//            {
//                throw new ArgumentException("Salário não encontrado");
//            }

//            // Atualiza os dados do salário
//            salarioExistente.Valor = salarioDto.Valor;
//            salarioExistente.DataPagamento = salarioDto.DataPagamento;

//            // Atualiza o salário no repositório
//            return await _salarioRepository.AtualizarSalario(salarioExistente);
//        }

//        public async Task<Salario> ObterSalario(int id)
//        {
//            // Obtém o salário do repositório pelo id
//            return await _salarioRepository.ObterSalario(id);
//        }

//        public async Task<List<Salario>> ListarSalario()
//        {
//            // Obtém a lista de salários do repositório
//            return await _salarioRepository.ListarSalarios();
//        }
//    }
//}
