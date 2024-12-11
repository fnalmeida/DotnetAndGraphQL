using DotnetAndGraphQL.Domain.Context;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAndGraphQL.Domain
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers(AppDbContext context) =>
            context.Customers;
    }

}
