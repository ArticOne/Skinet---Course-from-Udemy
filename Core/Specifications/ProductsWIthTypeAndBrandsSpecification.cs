using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ProductsWIthTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWIthTypeAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
        public ProductsWIthTypeAndBrandsSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
