﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class BookGenre
    {
        public string Id { get; set; }

        public string Genre { get; set; }

        public BookGenre()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}