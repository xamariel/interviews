﻿using System.Collections.Generic;

namespace Realmdigital_Interview.Models
{
    public class ApiResponseProduct
    {
        public int ProductId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public List<ApiResponsePrice> PriceRecords { get; set; }
    }
}