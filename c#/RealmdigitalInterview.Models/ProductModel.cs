﻿using System.Collections.Generic;

namespace RealmdigitalInterview.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public List<PriceModel> PriceRecords { get; set; }
    }
}
