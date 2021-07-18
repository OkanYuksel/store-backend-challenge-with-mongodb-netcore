using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.MedCore.Commands
{
    public class InsertProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
