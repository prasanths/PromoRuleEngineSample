using Moq;
using Promo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Promo.RuleEngine.Test
{
    public class PromoCalculatorTest: BaseTest
    {
        [Theory]
        [InlineData(130)]
        public void Check_ApplyPromotion_ActivePromo1(float expectedPrice)
        {
            var mockPromoCalc = new PromoCalculator();
            var cart = new Cart()
            {
                CartItems = new List<CartItem>() {
                   new CartItem(){ 
                        Count = 3,
                        Item = new Item()
                        {
                            Id = Guid.Parse("075e4a08-450c-4a62-8976-44fe53e06ab6"),
                            Name ="A",
                            Price = 50
                        }
                    }},
                Id = Guid.Parse("0796b451-ac60-4bfc-9b23-82aca28fca1c")
            };

            var actualPrice = mockPromoCalc.ApplyPromo(cart);
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Theory]
        [InlineData(45)]
        public void Check_ApplyPromotion_ActivePromo2(float expectedPrice)
        {
            var mockPromoCalc = new PromoCalculator();
            var cart = new Cart()
            {
                CartItems = new List<CartItem>() {
                   new CartItem(){
                        Count = 2,
                        Item = new Item()
                        {
                            Id = Guid.Parse("fe943937-758f-4092-8020-03deb5b63d29"),
                            Name = "B",
                            Price = 30
                        }
                    }},
                Id = Guid.Parse("84c9ff37-4397-4d6d-b8f9-975ca0398bf3")
            };

            var actualPrice = mockPromoCalc.ApplyPromo(cart);
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Theory]
        [InlineData(30)]
        public void Check_ApplyPromotion_ActivePromo3(float expectedPrice)
        {
            var mockPromoCalc = new PromoCalculator();
            var cart = new Cart()
            {
                CartItems = new List<CartItem>() {                    
                   new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("8cc027cf-694d-4ec6-8b7c-593ff84b293f"),
                            Name="C",
                            Price = 20
                        }
                    },
                   new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("2db9c7b9-83cf-4a78-b2ff-c21c228cd9dd"),
                            Name = "D",
                            Price = 15
                        }
                    }
                },
                Id = Guid.Parse("81e0f8d9-375e-4a7a-8f01-f3380512221e")
            };

            var actualPrice = mockPromoCalc.ApplyPromo(cart);
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Theory]
        [InlineData(60)]
        public void Check_ApplyPromotion_NoPromo(float expectedPrice)
        {
            var mockPromoCalc = new PromoCalculator();
            var cart = new Cart()
            {
                CartItems = new List<CartItem>() {
                   new CartItem(){
                        Count = 2,
                        Item = new Item()
                        {
                            Id = Guid.Parse("a9473f26-b310-4f30-b29c-dd100a521642"),
                            Name = "E",
                            Price = 30
                        }
                    }},
                Id = Guid.Parse("b1480fa6-facd-46cb-92f9-869f4375f16d")
            };

            var actualPrice = mockPromoCalc.ApplyPromo(cart);

            Assert.Equal(expectedPrice, actualPrice);
        }

        [Theory]
        [InlineData(100)]
        public void Check_ApplyPromotion_ScenarioA(float expectedPrice)
        {
            var mockPromoCalc = new PromoCalculator();
            var cart = new Cart()
            {
                CartItems = new List<CartItem>() {
                   new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("075e4a08-450c-4a62-8976-44fe53e06ab6"),
                            Name ="A",
                            Price = 50
                        }
                    },
                new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("fe943937-758f-4092-8020-03deb5b63d29"),
                            Name = "B",
                            Price = 30
                        }
                    },
                new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("8cc027cf-694d-4ec6-8b7c-593ff84b293f"),
                            Name="C",
                            Price = 20
                        }
                    }},
                Id = Guid.Parse("4823bc0f-86d2-48dc-9b2a-45c35f3b95c4")
            };

            var actualPrice = mockPromoCalc.ApplyPromo(cart);

            Assert.Equal(expectedPrice, actualPrice);
        }

        [Theory]
        [InlineData(370)]
        public void Check_ApplyPromotion_ScenarioB(float expectedPrice)
        {
            var mockPromoCalc = new PromoCalculator();
            var cart = new Cart()
            {
                CartItems = new List<CartItem>() {
                   new CartItem(){
                        Count = 5,
                        Item = new Item()
                        {
                            Id = Guid.Parse("075e4a08-450c-4a62-8976-44fe53e06ab6"),
                            Name ="A",
                            Price = 50
                        }
                    },
                new CartItem(){
                        Count = 5,
                        Item = new Item()
                        {
                            Id = Guid.Parse("fe943937-758f-4092-8020-03deb5b63d29"),
                            Name = "B",
                            Price = 30
                        }
                    },
                new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("8cc027cf-694d-4ec6-8b7c-593ff84b293f"),
                            Name="C",
                            Price = 20
                        }
                    }},
                Id = Guid.Parse("4823bc0f-86d2-48dc-9b2a-45c35f3b95c4")
            };

            var actualPrice = mockPromoCalc.ApplyPromo(cart);

            Assert.Equal(expectedPrice, actualPrice);
        }

        [Theory]
        [InlineData(280)]
        public void Check_ApplyPromotion_ScenarioC(float expectedPrice)
        {
            var mockPromoCalc = new PromoCalculator();
            var cart = new Cart()
            {
                CartItems = new List<CartItem>() {
                   new CartItem(){
                        Count = 3,
                        Item = new Item()
                        {
                            Id = Guid.Parse("075e4a08-450c-4a62-8976-44fe53e06ab6"),
                            Name ="A",
                            Price = 50
                        }
                    },
                new CartItem(){
                        Count = 5,
                        Item = new Item()
                        {
                            Id = Guid.Parse("fe943937-758f-4092-8020-03deb5b63d29"),
                            Name = "B",
                            Price = 30
                        }
                    },
                new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("8cc027cf-694d-4ec6-8b7c-593ff84b293f"),
                            Name="C",
                            Price = 20
                        }
                    },
                new CartItem(){
                        Count = 1,
                        Item = new Item()
                        {
                            Id = Guid.Parse("2db9c7b9-83cf-4a78-b2ff-c21c228cd9dd"),
                            Name = "D",
                            Price = 15
                        }
                    }},
                Id = Guid.Parse("4823bc0f-86d2-48dc-9b2a-45c35f3b95c4")
            };

            var actualPrice = mockPromoCalc.ApplyPromo(cart);

            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}
