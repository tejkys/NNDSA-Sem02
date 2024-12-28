using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNDSA_Sem02
{
    public class Product : IComparable<Product>
    {
        public static int Count { get; private set; } = 0;
        public string ProductNumber { get; set; }
        public Product()
        {
            //ProductNumber = (++Count).ToString();
            ProductNumber = new Random().NextInt64(1000, 9999).ToString();
        }
        
        public int CompareTo(Product? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(ProductNumber, other.ProductNumber, StringComparison.Ordinal);
        }
        public override string ToString() => ProductNumber;
    }
}
