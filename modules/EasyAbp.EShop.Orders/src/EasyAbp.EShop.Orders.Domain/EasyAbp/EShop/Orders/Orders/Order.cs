using System;
using System.Collections.Generic;
using EasyAbp.EShop.Stores.Stores;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EShop.Orders.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiStore
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid StoreId { get; protected set; }
        
        public virtual Guid CustomerUserId { get; protected set; }
        
        public virtual OrderStatus OrderStatus { get; protected set; }

        [NotNull]
        public virtual string Currency { get; protected set; }
        
        public virtual decimal ProductTotalPrice { get; protected set; }
        
        public virtual decimal TotalDiscount { get; protected set; }
        
        public virtual decimal TotalPrice { get; protected set; }
        
        public virtual decimal RefundedAmount { get; protected set; }
        
        [CanBeNull]
        public virtual string CustomerRemark { get; protected set; }
        
        [CanBeNull]
        public virtual string StaffRemark { get; protected set; }
        
        public virtual DateTime? PaidTime { get; protected set; }
        
        public virtual DateTime? CompletionTime { get; protected set; }
        
        public virtual DateTime? CancelledTime { get; protected set; }
        
        public virtual DateTime? ReducedInventoryAfterPlacingTime { get; protected set; }
        
        public virtual DateTime? ReducedInventoryAfterPaymentTime { get; protected set; }
        
        public virtual List<OrderLine> OrderLines { get; protected set; }

        protected Order()
        {
            OrderLines = new List<OrderLine>();
        }

        public Order(
            Guid id,
            Guid? tenantId,
            Guid storeId,
            Guid customerUserId,
            string currency,
            decimal productTotalPrice,
            decimal totalDiscount,
            decimal totalPrice,
            decimal refundedAmount,
            [CanBeNull] string customerRemark
        ) : base(id)
        {
            TenantId = tenantId;
            StoreId = storeId;
            CustomerUserId = customerUserId;
            Currency = currency;
            ProductTotalPrice = productTotalPrice;
            TotalDiscount = totalDiscount;
            TotalPrice = totalPrice;
            RefundedAmount = refundedAmount;
            CustomerRemark = customerRemark;

            OrderStatus = OrderStatus.Pending;
            OrderLines = new List<OrderLine>();
        }

        public void SetOrderLines(List<OrderLine> orderLines)
        {
            OrderLines = orderLines;
        }

        public void SetReducedInventoryAfterPlacingTime(DateTime? time)
        {
            ReducedInventoryAfterPlacingTime = time;
        }

        public void SetReducedInventoryAfterPaymentTime(DateTime? time)
        {
            ReducedInventoryAfterPaymentTime = time;
        }
    }
}
