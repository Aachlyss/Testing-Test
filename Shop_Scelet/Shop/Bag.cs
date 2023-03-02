using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Bag
    {

        private const int defaultCapacity = 100;
        public Bag( int freeCapacity=defaultCapacity)
        {
            this.FreeCapacity = freeCapacity;
            this.Products= new List<Product>();
        }

        

        public List<Product> Products { get; set; }
        public int FreeCapacity { get; set; }

        public void AddProduct(Product product)
        {
            if (this.FreeCapacity <= 0)
            {
                throw new InvalidOperationException("Invalid operation");
            }
            this.Products.Add(product);
            this.FreeCapacity = this.FreeCapacity-1;
        }

        public void RemoveProductByName(string name)
        {
            if (this.Products.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation");
            }

            var productToRemove = this.Products.FirstOrDefault(x => x.Name == name);
            if (productToRemove == null)
            {
                throw new InvalidOperationException("Invalid operation");
            }
            
            this.Products.Remove(productToRemove);
            this.FreeCapacity = this.FreeCapacity +1;
        }

        public void EmptyBag()
        {
            this.Products.Clear();
            this.FreeCapacity = defaultCapacity;

        }

    }
}
