using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCSharp.BLL.Models;
using TesteCSharp.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteCSharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly Contexto _contexto;

        public ClientesController(Contexto contexto)
        {
            _contexto = contexto;
        }
       
        [HttpPost]
        public async Task<ActionResult> InserirCliente(Cliente cliente)
        {
            try
            {
                await _contexto.AddAsync(cliente);
                await _contexto.SaveChangesAsync();

                return Ok(new
                {
                    mensagem = "Objeto Salvo"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex
                });
            }
         
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarCliente(long id , Cliente cliente)
        {
            if(cliente.ClienteId != id)
            {
                return BadRequest();
            }

            try
            {
                var retorno = _contexto.Clientes.Include(c => c.ClienteEmpresas)
                    .FirstOrDefaultAsync(c => c.ClienteId == id);

                if(retorno == null)
                {
                    BadRequest();
                }

                Cliente clienteAtualizado = new Cliente();
                clienteAtualizado = await retorno;
                            
                _contexto.Update(clienteAtualizado);
                await _contexto.SaveChangesAsync();

                return Ok(new
                {
                    mensagem = "Objeto Atualizado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex
                });
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(long id)
        {
            var excluir = _contexto.Clientes.FirstOrDefault(c => c.ClienteId == id);

            if(excluir != null)
            {
                _contexto.Clientes.Remove(excluir);
                await _contexto.SaveChangesAsync();

                return Ok(true);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("Consultar/{cpf}/{nome}")]

        public async Task<ActionResult<IEnumerable<Cliente>>> ConsultarClientesCpfNome(string cpf , string nome)
        {
            try
            {
                var retorno = await _contexto.Clientes
                    .Include(c => c.ClienteEmpresas)
                    .Where(c => c.CPF.Contains(cpf) ||
                    c.Nome.Contains(nome)).ToListAsync();

                return retorno;

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}



// Json utilizado para testes
// Inserir
//{
//    "cpf": "3396503686",
//  "nome": "Marco Antonio Junior",
//  "email": "marco.junior@uol.com",
//  "dataCricao": "2021-09-13T23:59:59",
//  "clienteEmpresas": [
//  {
//        "empresaId": 3
//  }
//  ]
//}
// Atualizar
//{
//    "clienteId": 1,
//  "cpf": "99365036866",
//  "nome": "Marco Antonio Goncalves",
//  "email": "marco.junior@gmail.com",
//  "dataCricao": "2021-09-10T23:59:59",
//  "clienteEmpresas": [
//  {
//        "clienteId": 1,
//  "empresaId": 1
//  }
//  ]
//}
//Deletar
////https://localhost:44366/api/Clientes/Consultar/{id}
//
//Consultar
//https://localhost:44366/api/Clientes/Consultar/{cpf}/{nome}