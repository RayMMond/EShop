using System;
using EasyAbp.EShop.Stores.StoreOwners.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.EShop.Stores.StoreOwners
{
    public interface IStoreOwnerAppService :
        IReadOnlyAppService<
            StoreOwnerDto,
            Guid,
            GetStoreOwnerListDto>
    {
    }
}
