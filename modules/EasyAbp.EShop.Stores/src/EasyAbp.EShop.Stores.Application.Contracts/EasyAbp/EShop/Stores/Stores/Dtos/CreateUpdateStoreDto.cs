using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.EShop.Stores.Stores.Dtos
{
    public class CreateUpdateStoreDto
    {
        [Required]
        [DisplayName("StoreName")]
        public string Name { get; set; }

        [DisplayName("StoreOwner")]
        public ICollection<Guid> OwnerIds { get; set; }
    }
}