using System;
using Microsoft.AspNetCore.Authorization;

namespace EasyAbp.EShop.Stores.Permissions
{
    public class StorePermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public StorePermissionAuthorizationRequirement(Guid storeId, string permissionName = null)
        {
            StoreId = storeId;
            PermissionName = permissionName;
        }

        public Guid StoreId { get; }

        public string PermissionName { get; }
    }
}
