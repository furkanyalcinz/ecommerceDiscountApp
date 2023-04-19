﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public uint Stock { get; set; }
        public uint Price { get; set; }
        public uint CategoryId { get; set; }
        public uint SellingPrice { get; set; }
        
        public virtual Category Category { get; set; }
    }
}
