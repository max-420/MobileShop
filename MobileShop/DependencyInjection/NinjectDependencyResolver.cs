using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MobileShop.Services;
using MobileShop.Repository;
using System.Reflection;

namespace MobileShop.DependencyInjection
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind(typeof(IGoodsRepository<>)).To(typeof(GoodsRepository<>));
            kernel.Bind(typeof(IRepositoryFactory)).ToFactory(typeof(IRepositoryFactory));
            kernel.Bind(typeof(ApplicationContext)).ToSelf().InRequestScope();

            kernel.Bind(typeof(ICRUDService<>)).To(typeof(CRUDService<>));
            kernel.Bind(typeof(ICatalogService)).To(typeof(CatalogService));
            kernel.Bind(typeof(IReviewService)).To(typeof(ReviewService));
            kernel.Bind(typeof(IOrderService)).To(typeof(OrderService));
            kernel.Bind(typeof(IImageService)).To(typeof(ImageService));
        }
    }
    public class GenericFactoryMethodInstanceProvider : StandardInstanceProvider
    {
        protected override string GetName(MethodInfo methodInfo, object[] arguments)
        {
            var genericTypeArguments = methodInfo.GetGenericArguments();
            return genericTypeArguments[0].Name;
        }
    }
}