using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Modals;
using PrimeiraApi.Service.FuncionarioService;
using System.Collections.Generic;

namespace PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface) // puxa as ações da interface
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServerResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            ServerResponse<FuncionarioModel> serverResponse = await _funcionarioInterface.GetFuncionarioById(id);
            return Ok(serverResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }
        [HttpPut]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);
            return Ok(serverResponse);
        }
        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = await _funcionarioInterface.InativaFuncionario(id);
            return Ok(serverResponse);
        }
        [HttpDelete]
        public async Task<ActionResult<ServerResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            ServerResponse<List<FuncionarioModel>> serverResponse = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(serverResponse);
        }

    }
}