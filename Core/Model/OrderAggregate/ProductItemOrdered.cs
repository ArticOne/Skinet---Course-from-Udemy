using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.OrderAggregate
{
    public class ProductItemOrdered
    {
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }

        public ProductItemOrdered()
        {

        }
        public ProductItemOrdered(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }
    }
}
