﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.ViewModels
{
    public class BasketItemViewModel
    {
        public string Id{get; set;}
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

}
