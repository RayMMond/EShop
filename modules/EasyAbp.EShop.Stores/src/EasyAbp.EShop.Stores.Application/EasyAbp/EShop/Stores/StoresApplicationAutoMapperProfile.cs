using EasyAbp.EShop.Stores.Stores;
using EasyAbp.EShop.Stores.Stores.Dtos;
using AutoMapper;
using EasyAbp.EShop.Stores.StoreOwners;
using EasyAbp.EShop.Stores.StoreOwners.Dtos;
using Volo.Abp.AutoMapper;

namespace EasyAbp.EShop.Stores
{
    public class StoresApplicationAutoMapperProfile : Profile
    {
        public StoresApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Store, StoreDto>();
            CreateMap<CreateUpdateStoreDto, Store>(MemberList.Source)
                .ForSourceMember(x=>x.OwnerIds, opt=> opt.DoNotValidate());

            CreateMap<StoreOwner, StoreOwnerDto>();

        }
    }
}
