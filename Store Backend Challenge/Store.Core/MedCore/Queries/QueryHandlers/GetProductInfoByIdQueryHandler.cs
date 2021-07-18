using MediatR;
using Store.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.MedCore.Queries
{
    public class GetProductInfoByIdQueryHandler : IRequestHandler<GetProductInfoByIdQuery, Product>
    {
        private readonly IProductServices _productServices;
        public GetProductInfoByIdQueryHandler(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public Task<Product> Handle(GetProductInfoByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = _productServices.GetProduct(request.Id);

            return Task.FromResult(product);
        }
    }
}
