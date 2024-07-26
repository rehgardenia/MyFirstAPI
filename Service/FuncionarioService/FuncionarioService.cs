using Microsoft.EntityFrameworkCore;
using PrimeiraApi.DataContext;
using PrimeiraApi.Modals;

namespace PrimeiraApi.Service.FuncionarioService
{

    public class FuncionarioService : IFuncionarioInterface  // os requisitos sao conectados com o banco
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context) { // se conectar com o banco de dados
            _context = context;
        }

        public async Task<ServerResponse<List<FuncionarioModel>>> GetFuncionarios() // retorna uma lista 
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();

            try
            {
                serverResponse.Dados = _context.Funcionarios.ToList(); // enviar os funcionarios do banco para o dados do resultado   
                if(serverResponse.Dados.Count == 0)
                {
                    serverResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;  // informa o frontend caso de algum problema 
            }
            return serverResponse;
        }
        public async Task<ServerResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServerResponse<FuncionarioModel> serverResponse = new ServerResponse<FuncionarioModel>();
            try { 
        
                FuncionarioModel? funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if(funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Usuário não localizado!";
                    serverResponse.Sucesso=false;
                }
                serverResponse.Dados = funcionario;
            }
            catch (Exception ex)
            {
                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
           

        }

        public async Task<ServerResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                if(novoFuncionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Informe os Dados!";
                    serverResponse.Sucesso = false;

                    return serverResponse;
                }
                else
                {
                    serverResponse.Mensagem = "Adicionado com Sucesso!";
                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serverResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex) {
                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }

            return serverResponse;

        }
        public async Task<ServerResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try {
                FuncionarioModel? funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);
                if (funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Usuário não encontrado!";
                    serverResponse.Sucesso = false;
                }
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editadoFuncionario);

                await _context.SaveChangesAsync();

                serverResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
        }
        public async Task<ServerResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if (funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Sucesso = false;
                    serverResponse.Mensagem = "Usuário não encontrado!";
                }
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serverResponse.Dados = _context.Funcionarios.ToList();
            }
             catch (Exception ex)
            {
                serverResponse.Mensagem = ex.Message;
                serverResponse.Sucesso = false;
            }
            return serverResponse;
        }


        public async Task<ServerResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
           ServerResponse<List<FuncionarioModel>> serverResponse = new ServerResponse<List<FuncionarioModel>>();
            try
            {
                // pegar o usuário do banco 
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                // se for nulo, altera o serverResponse
                if (funcionario == null)
                {
                    serverResponse.Dados = null;
                    serverResponse.Mensagem = "Usuário não encontrado!";
                    serverResponse.Sucesso = false;
                }
                //senão, desativa o usuário e a data de alteração
                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                // atualiza o banco de dados
                _context.Funcionarios.Update(funcionario);
                // salva as mudanças
                await _context.SaveChangesAsync();
                // faz um select no banco e retorna uma lista
                serverResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex) { 
            serverResponse.Mensagem = ex.Message;
            serverResponse.Sucesso = false;
            }
            return serverResponse;

        }

        
    }
}
