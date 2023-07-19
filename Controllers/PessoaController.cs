using ApiTesteRavenDb.Extensoes;
using ApiTesteRavenDb.Infra;
using ApiTesteRavenDb.model;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Linq;

namespace ApiTesteRavenDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public List<Pessoa> ObterTodos()
        {
            using var sessao = ControladorDeDocumentos.Store.OpenSession();
            return sessao.Query<Pessoa>().ToList();
        }

        [HttpGet]
        [Route("id")]
        public Pessoa ObterPorId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException($"Não foi possível realizar a consulta, pois, o id não foi informado.");

            using var sessao = ControladorDeDocumentos.Store.OpenSession();
            return sessao.Pessoa().Where(x => x.Id == id).FirstOrDefault() ??
                throw new Exception($"Pessoa com o identificador ({id}), não foi encontrada.");
        }

        [HttpPost]
        public CreatedResult Criar(Pessoa pessoa)
        {
            if (pessoa is null)
                throw new ArgumentNullException("Não foi possível realizar cadastro");

            using var sessao = ControladorDeDocumentos.Store.OpenSession();
            sessao.Store(pessoa);

            return Created("api/Pessoa", pessoa);
        }

        [HttpPut]
        public NoContentResult Atualizar(Pessoa pessoa)
        {
                using var sessao = ControladorDeDocumentos.Store.OpenSession();

                var pessoaDoBanco = sessao.Pessoa().Where(x => x.Id == pessoa.Id).FirstOrDefault() ??
                throw new Exception($"Pessoa com o identificador ({pessoa.Id}), não foi encontrada.");

                pessoaDoBanco.Nome = pessoa.Nome;
                pessoaDoBanco.Cargo = pessoa.Cargo;

            return NoContent();
        }
    }
}