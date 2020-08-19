using Newtonsoft.Json;
using Promo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Promo.RuleEngine
{
    public class PromoCalculator: IPromoCalculator
    {
        private IList<Promotion> promotions = new List<Promotion>(); // Get All
        public PromoCalculator()
        {
            promotions = JsonConvert.DeserializeObject<List<Promotion>>(File.ReadAllText("promotions.json"));
        }

        public float ApplyPromo(Cart cart)
        {
            float totalCost = 0;
            foreach(var item in cart.CartItems)
            {
                var applicablePromos = this.GetAllPromotionsForItem(item.Item.Id);
                if (applicablePromos.Count() > 0)
                {
                    foreach (var promo in applicablePromos.Where(p => p.Count > 0))
                    {
                        if (item.Count == promo.Count)
                        {
                            totalCost += promo.Price;
                            item.PromoApplied = true;
                        }
                        else if (item.Count > promo.Count)
                        {
                            var rem = item.Count % promo.Count;
                            var promoUnits = item.Count / promo.Count;
                            if (rem == 0)
                            {
                                totalCost += (promoUnits * promo.Price);
                            }
                            else
                            {
                                totalCost += (promoUnits * promo.Price) + rem * item.Item.Price;
                            }
                            item.PromoApplied = true;
                        }
                        else
                        {
                            totalCost += item.Item.Price * item.Count;
                            item.PromoApplied = true;
                        }

                    }

                    foreach (var promo in applicablePromos.Where(p => p.Count == 0))
                    {
                        var combinationItems = cart.CartItems.Where(p => p.PromoApplied == false && promo.ItemsInvolved.Any(x => x.Id == p.Item.Id));
                        if (combinationItems.Count() > 1)
                        {
                            foreach (var combItem in combinationItems)
                            {
                                combItem.PromoApplied = true;
                            }
                            totalCost += item.Count * promo.Price;
                        }
                        else
                        {
                            if (item.PromoApplied == false)
                            {
                                totalCost += item.Item.Price * item.Count;
                                item.PromoApplied = true;
                            }
                        }
                    }
                }
                else
                {
                    totalCost += item.Item.Price * item.Count;
                }
                
            }

            return totalCost;
        }

        public IEnumerable<Promotion> GetAllPromotionsForItem(Guid itemId)
        {
            var applicablePromos = promotions.Where(p => p.ItemsInvolved.Any(x => x.Id == itemId));

            return applicablePromos;
        }
    }
}
