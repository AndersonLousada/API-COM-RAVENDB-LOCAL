using ApiTesteRavenDb.model;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace ApiTesteRavenDb.Extensoes
{
    public static class ExtensoesDasQuerys
    {
        public static IRavenQueryable<Pessoa> Pessoa(this IDocumentSession sessao)
        {
            return sessao.Query<Pessoa>();
        }

        public static IRavenQueryable<Pessoa> PorId(this IDocumentSession sessao)
        {
            return sessao.Query<Pessoa>();
        }
    }
}
