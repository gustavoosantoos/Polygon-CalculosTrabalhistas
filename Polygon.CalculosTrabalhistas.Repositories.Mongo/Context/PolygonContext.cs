using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.CalculosTrabalhistas.Repositories.Raven.Context
{
    public class PolygonContext
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Instance
        {
            get { return store.Value; }
        }

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new [] { "http://localhost:9001" },
                Database = "Polygon"
            }.Initialize();

            return store;
        }
    }
}
