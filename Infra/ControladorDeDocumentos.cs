using Raven.Client.Documents;

namespace ApiTesteRavenDb.Infra
{
    public class ControladorDeDocumentos
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://localhost:8080"},

                Conventions =
                {
                    MaxNumberOfRequestsPerSession = 10,
                    UseOptimisticConcurrency = true,
                    IdentityPartsSeparator = '-',
                    SaveEnumsAsIntegers = true,
                },

                Database = "ApiTesteRavenDb",
            }.Initialize();

            return store;
        }
    }
}
