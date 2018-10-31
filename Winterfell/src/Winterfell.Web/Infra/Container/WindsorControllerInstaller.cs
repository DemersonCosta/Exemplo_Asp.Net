using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Winterfell.Core.Domain.Controller;
using Winterfell.Web.Controllers;

namespace Winterfell.Web.Infra.Container
{
    /// <summary>
    /// Registra todos os controllers da aplicação no Windsor Container
    /// </summary>
    public class WindsorControllerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Registra todos os controllers da aplicação.
        /// </summary>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<HomeController>()
                 .BasedOn(typeof(IWinterfellController))
                 .Configure(c => c.LifestyleTransient()));
        }
    }
}