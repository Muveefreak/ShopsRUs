using ShopsRUs.Core.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Orders.Interfaces
{
    public interface IOrderService
    {
        Task<Decimal> GetTotalInvoice(long customerId, CancellationToken cancellationToken);
    }
}
