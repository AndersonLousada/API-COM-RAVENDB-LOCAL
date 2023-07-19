using ApiTesteRavenDb.Infra;
using ApiTesteRavenDb.model;
using Raven.Migrations;

namespace ApiTesteRavenDb.Migrations
{
    [Migration(20230717155101)]
    public class _20230717155101_CriarPessoaPadrao : Migration
    {
        public override void Up()
        {
            using var sessao = ControladorDeDocumentos.Store.OpenSession();

            var administrador = new Pessoa()
            {
                Nome = "Anderson",
                Cargo = "Development",
            };

            sessao.Store(administrador);
            sessao.SaveChanges();
        }

        public override void Down()
        {

        }
    }
}