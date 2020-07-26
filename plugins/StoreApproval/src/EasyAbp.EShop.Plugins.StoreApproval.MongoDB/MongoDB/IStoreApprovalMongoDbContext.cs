﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.EShop.Plugins.StoreApproval.MongoDB
{
    [ConnectionStringName(StoreApprovalDbProperties.ConnectionStringName)]
    public interface IStoreApprovalMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
