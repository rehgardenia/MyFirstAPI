using PrimeiraApi.Modals;

namespace PrimeiraApi.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        //ações a serem requisitadas pelo https
        Task<ServerResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServerResponse<FuncionarioModel>> GetFuncionarioById(int id);
        Task<ServerResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);

        Task<ServerResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario);

        Task<ServerResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);

        Task<ServerResponse<List<FuncionarioModel>>> InativaFuncionario(int id);


    }
}
