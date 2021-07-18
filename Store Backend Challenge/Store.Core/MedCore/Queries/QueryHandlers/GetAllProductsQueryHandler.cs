using MediatR;
using Store.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.MedCore.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductServices _productServices;
        public GetAllProductsQueryHandler(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> productList = _productServices.GetProducts();

            return Task.FromResult(productList);
        }
    }
}
