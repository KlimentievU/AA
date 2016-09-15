using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //получить об Сart из сеанса
            Cart cart = (Cart) controllerContext.HttpContext.Session[sessionKey];
            //coздать экземплак класса ели его еще ету 
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            //вернуть обьект сart
            return cart;
        }
    }

}