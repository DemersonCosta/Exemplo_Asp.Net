using Castle.Core;
using Castle.MicroKernel;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Winterfell.Core.Domain.Services;

namespace Winterfell.Web.App_Data
{
    public class DataService: IService, IStartable
    {
        private readonly IKernel _kernel;

        public DataService(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Start()
        {
            new SchemaExport(_kernel.Resolve<Configuration>()).Create(true, false);
        }

        public void Stop()
        {

        }
    }
}