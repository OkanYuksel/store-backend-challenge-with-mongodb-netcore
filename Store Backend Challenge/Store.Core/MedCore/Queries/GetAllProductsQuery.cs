using MediatR;
using Store.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.MedCore.Queries
{
    public class GetAllProductsQuery: IRequest<List<Product>>
    {
    }
}
