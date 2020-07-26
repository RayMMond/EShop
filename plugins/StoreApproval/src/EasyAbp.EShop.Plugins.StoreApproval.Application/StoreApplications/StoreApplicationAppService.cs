using EasyAbp.EShop.Plugins.StoreApproval.Permissions;
using EasyAbp.EShop.Plugins.StoreApproval.StoreApplications.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace EasyAbp.EShop.Plugins.StoreApproval.StoreApplications
{
    public class StoreApplicationAppService : CrudAppService<StoreApplication, StoreApplicationDto, Guid, PagedAndSortedResultRequestDto, CreateStoreApplicationDto, UpdateStoreApplicationDto>,
        IStoreApplicationAppService
    {
        protected IdentityUserManager UserManager;
        protected override string GetPolicyName { get; set; } = StoreApprovalPermissions.StoreApplication.Default;
        protected override string GetListPolicyName { get; set; } = StoreApprovalPermissions.StoreApplication.Default;
        protected override string CreatePolicyName { get; set; } = StoreApprovalPermissions.StoreApplication.Create;
        protected override string UpdatePolicyName { get; set; } = StoreApprovalPermissions.StoreApplication.Update;
        protected override string DeletePolicyName { get; set; } = StoreApprovalPermissions.StoreApplication.Delete;
        protected virtual string ApprovalPolicyName { get; set; } = StoreApprovalPermissions.StoreApplication.Approval;

        public StoreApplicationAppService(IRepository<StoreApplication, Guid> repository,
            IdentityUserManager userManager) : base(repository)
        {
            UserManager = userManager;
        }

        public override async Task<StoreApplicationDto> CreateAsync(CreateStoreApplicationDto input)
        {
            await CheckCreatePolicyAsync();

            var user = await UserManager.GetByIdAsync(input.ApplicantId);

            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        public async Task<StoreApplicationDto> SubmitAsync(Guid id)
        {
            await CheckCreatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);
            entity.Submit();

            await Repository.UpdateAsync(entity);

            return ObjectMapper.Map<StoreApplication, StoreApplicationDto>(entity);
        }

        public async Task<StoreApplicationDto> ApproveAsync(Guid id)
        {
            await CheckPolicyAsync(ApprovalPolicyName);

            var entity = await GetEntityByIdAsync(id);
            entity.Approve();

            await Repository.UpdateAsync(entity);

            return ObjectMapper.Map<StoreApplication, StoreApplicationDto>(entity);
        }

        public async Task<StoreApplicationDto> RejectAsync(Guid id)
        {
            await CheckPolicyAsync(ApprovalPolicyName);

            var entity = await GetEntityByIdAsync(id);
            entity.Reject();

            await Repository.UpdateAsync(entity);

            return ObjectMapper.Map<StoreApplication, StoreApplicationDto>(entity);
        }
    }
}