using EasyAbp.EShop.Stores.StoreOwners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.EShop.Stores.Stores
{
    public class StoreManager : DomainService, IStoreManager
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IStoreOwnerRepository _storeOwnerRepository;

        public StoreManager(IStoreRepository storeRepository,
            IStoreOwnerRepository storeOwnerRepository)
        {
            _storeRepository = storeRepository;
            _storeOwnerRepository = storeOwnerRepository;
        }

        public async Task<Store> CreateAsync(Store store, IEnumerable<Guid> ownerIds = null)
        {
            store = await _storeRepository.InsertAsync(store);

            await UpdateStoreOwnersAsync(store.Id, ownerIds);

            return store;
        }

        public async Task<Store> UpdateAsync(Store store, IEnumerable<Guid> ownerIds = null)
        {
            store = await _storeRepository.UpdateAsync(store);

            await UpdateStoreOwnersAsync(store.Id, ownerIds);

            return store;
        }

        public Task DeleteAsync(Store store)
        {
            return _storeRepository.DeleteAsync(store);
        }

        public Task DeleteAsync(Guid id)
        {
            return _storeRepository.DeleteAsync(id);
        }

        protected virtual async Task UpdateStoreOwnersAsync(Guid storeId, IEnumerable<Guid> ownerIds)
        {
            ownerIds ??= new List<Guid>();

            var storeOwners = await _storeOwnerRepository.GetListByStoreIdAsync(storeId);

            foreach (var storeOwner in storeOwners.Where(x => !ownerIds.Contains(x.OwnerId)).ToList())
            {
                await _storeOwnerRepository.DeleteAsync(storeOwner, true);
            }

            foreach (var ownerId in ownerIds.Except(storeOwners.Select(x => x.OwnerId).ToList()))
            {
                await _storeOwnerRepository.InsertAsync(
                    new StoreOwner(GuidGenerator.Create(), ownerId, ownerId, CurrentTenant.Id), true);
            }
        }
    }
}