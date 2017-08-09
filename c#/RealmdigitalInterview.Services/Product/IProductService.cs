﻿using RealmdigitalInterview.Models;
using System.Collections.Generic;

namespace RealmdigitalInterview.Services.Product
{
    public interface IProductService
    {
        List<ProductModel> GetProductsByName(string productName);
    }
}
