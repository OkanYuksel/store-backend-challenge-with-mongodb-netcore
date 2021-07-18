using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Core.MedCore.Commands.CommandHandlers
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, Product>
    {
        private readonly IProductServices _productServices;
        public InsertProductCommandHandler(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public Task<Product> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            _productServices.AddProduct(request.Product);
            return Task.FromResult(request.Product);
        }
    }
}
