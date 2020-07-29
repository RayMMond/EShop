﻿using EasyAbp.EShop.Orders.Orders.Dtos;
using AutoMapper;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.EShop.Orders.Web
{
    public class OrdersWebAutoMapperProfile : Profile
    {
        public OrdersWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<OrderDto, CreateOrderDto>()
                .MapExtraProperties(MappingPropertyDefinitionChecks.Both);
            CreateMap<OrderLineDto, CreateOrderLineDto>();
        }
    }
}
