using BookStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Core.Contracts
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string bookId);
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
        List<BasketItemViewModel> GetBasketItem(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);




    }
}
