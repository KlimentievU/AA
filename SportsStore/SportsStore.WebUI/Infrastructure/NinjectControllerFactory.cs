using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjetKernel;

        public NinjectControllerFactory()
        {
            ninjetKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) ninjetKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            /*Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product() {Name = "Football",Price = 25},
                new Product() {Name = "Surf board", Price = 179},
                new Product() {Name = "Running shoes", Price = 95},
            }.AsQueryable());
            ninjetKernel.Bind<IProductsRepository>().ToConstant(mock.Object);*/
            ninjetKernel.Bind<IProductsRepository>().To<EFProductRepositoty>();
        }
    }
}