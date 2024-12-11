using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using HemenBiletProje.Services;
using HemenBiletProje.Repositories;
using Ninject.Web.Mvc; 

namespace HemenBiletProje
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // Ninject Kernel'ı global olarak tutuyoruz
        public static IKernel Kernel { get; private set; }

        protected void Application_Start()
        {
            // Ninject DI Container'ını başlatıyoruz
            Kernel = new StandardKernel();
            RegisterServices(Kernel);

            // DI Resolver'ını ayarlıyoruz
            DependencyResolver.SetResolver(new NinjectDependencyResolver(Kernel));

            // Diğer başlangıç işlemleri
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Servisleri burada kaydediyoruz
        private void RegisterServices(IKernel kernel)
        {
            // UserRepository ve UserService'i DI container'a bağlıyoruz
            kernel.Bind<UserRepository>().ToSelf().InRequestScope();
            kernel.Bind<UserService>().ToSelf().InRequestScope();
        }
    }
}
