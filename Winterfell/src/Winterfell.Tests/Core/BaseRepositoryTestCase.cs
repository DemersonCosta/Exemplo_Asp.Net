using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Winterfell.Core;

namespace Winterfell.Tests.Core
{
    public class BaseRepositoryTestCase
    {
        protected DefaultContainer Container;

        [TestInitialize]
        public void Setup()
        {
            Container = new DefaultContainer();
            Container.SetupForTests();

            new SchemaExport(Container.Resolve<Configuration>()).Create(true, true);
        }
    }
}