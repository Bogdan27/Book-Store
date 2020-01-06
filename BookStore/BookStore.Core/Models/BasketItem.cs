using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class BasketItem : BookEntity
    {
        public string BasketId { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
    }
}
