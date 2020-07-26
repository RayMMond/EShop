using System;
using System.Threading.Tasks;
using EasyAbp.EShop.Plugins.StoreApproval.StoreApplications.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.EShop.Plugins.StoreApproval.StoreApplications
{
    public interface IStoreApplicationAppService :
        ICrudAppService< 
            StoreApplicationDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateStoreApplicationDto,
            UpdateStoreApplicationDto>
    {
        Task<StoreApplicationDto> SubmitAsync(Guid id);

        Task<StoreApplicationDto> ApproveAsync(Guid id);

        Task<StoreApplicationDto> RejectAsync(Guid id);
    }
}