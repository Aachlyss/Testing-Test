using NUnit.Framework;
using Shop;
using System;

namespace ShopTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProductConstructorShouldInitializeProductCorrectly()
        {
            Product product = new Product("Cucumba",7);

            Assert.AreEqual("Cucumba", product.Name);
            Assert.AreEqual(7, product.Price);
        }


        [Test]
        public void BagConstructorShouldInicializeCorrectly()
        {
            Bag bag = new Bag(100);

            Assert.AreEqual(100, bag.FreeCapacity);
        }

        [Test]
        public void AddMethodShoudWorkCorrectlyAndReduceFreeCapacity()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);

            bag.AddProduct(product);

            Assert.AreEqual(99, bag.FreeCapacity);

        }
        [Test]
        public void AddMethodShoudWorkCorrectlyAndAddProductToList()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);

            bag.AddProduct(product);

            Assert.AreEqual(1, bag.Products.Count);
        }
        [Test]
        public void AddMethodShoudWorkCorrectlyAndAddExactliOneProductToList()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);

            bag.AddProduct(product);

            Assert.AreEqual(1, bag.Products.Count);
        }

        [Test]
        public void AddMethodShoudThrowInvalidOperationException()
        {
            Bag bag = new Bag(0);
            Product product = new Product("Cucumba", 7);

            Assert.Throws<InvalidOperationException>(()=>bag.AddProduct(product));
        }

        [Test]
        public void AddMethodShoudThrowExactMessage()
        {
            Bag bag = new Bag(0);
            Product product = new Product("Cucumba", 7);

            var ex = Assert.Throws<InvalidOperationException>(() => bag.AddProduct(product));

            Assert.AreEqual("Invalid operation", ex.Message);

        }
        //Remove

        [Test]
        public void RemoveMethodShoudThrowInvalidOperationExWhenThereIsNoProductInTheList()
        {
            Bag bag = new Bag(100);
            //Product product = new Product("Cucumba", 7);
            Assert.Throws<InvalidOperationException>(() => bag.RemoveProductByName("Cheese"));
        }
        [Test]
        public void RemoveMethodShoudThrowExactMessageWhenThereIsNoProductInTheList()
        {
            Bag bag = new Bag(100);
            var ex = Assert.Throws<InvalidOperationException>(() => bag.RemoveProductByName("Cucumba"));
            Assert.AreEqual("Invalid operation", ex.Message);
        }

        [Test]
        public void RemoveMethodShoudThrowInvalidOperationExWhenThereIsNoSuchProductInTheList()
        {
            Bag bag = new Bag(100);
            Assert.Throws<InvalidOperationException>(() => bag.RemoveProductByName("Cucumba"));
        }

        [Test]
        public void RemoveMethodShoudThrowExactMessageWhenThereIsNoSuchProductInTheList()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);
            bag.AddProduct(product);
            var ex = Assert.Throws<InvalidOperationException>(() => bag.RemoveProductByName("Cheese"));
            Assert.AreEqual("Invalid operation", ex.Message);
        }

        [Test]
        public void RemoveMethodShoudRemoveProductAndDecreseCountOfListOfProducts()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);
            bag.AddProduct(product);
            bag.RemoveProductByName("Cucumba");

            Assert.AreEqual(0, bag.Products.Count);

        }
        [Test]
        public void RemoveMethodShoudRemoveProductAndDIncreaseFreeCapacity()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);
            bag.AddProduct(product);
            bag.RemoveProductByName("Cucumba");

            Assert.AreEqual(100, bag.FreeCapacity);
        }
        [Test]
        public void RemoveMethodShoudRemoveExactProduct()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);
            bag.AddProduct(product);
            bag.RemoveProductByName("Cucumba");

            bool isProduct = false;
            if (bag.Products.Contains(product))
            {
                isProduct = true;
            }

            Assert.AreEqual(false, isProduct);


        }

        [Test]
        public void EmptyMethodShoudWorkCorrectly()
        {
            Bag bag = new Bag(100);
            Product product = new Product("Cucumba", 7);
            bag.AddProduct(product);

            bag.EmptyBag();

            Assert.AreEqual(100, bag.FreeCapacity);
        }


    }
}