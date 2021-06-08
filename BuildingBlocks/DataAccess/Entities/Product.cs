﻿using System;

namespace DataAccess.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Value { get; set; }

    }
}
