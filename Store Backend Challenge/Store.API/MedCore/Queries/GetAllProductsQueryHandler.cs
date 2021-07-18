using MediatR;
using Store.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.API.MedCore.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product { Id = Guid.NewGuid().ToString(), ProductName = "testProductName", UnitPrice = 11, UnitType = "KG" });

            return Task.FromResult(productList);
        }
    }
}
