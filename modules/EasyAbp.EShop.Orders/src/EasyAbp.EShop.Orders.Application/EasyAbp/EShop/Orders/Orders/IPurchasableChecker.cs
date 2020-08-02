﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.EShop.Orders.Orders.Dtos;
using EasyAbp.EShop.Products.Products.Dtos;

namespace EasyAbp.EShop.Orders.Orders
{
    public interface IPurchasableChecker
    {
        Task CheckAsync(CreateOrderDto input, Dictionary<Guid, ProductDto> productDict);
    }
}