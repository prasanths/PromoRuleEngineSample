using Promo.Model;

namespace Promo.RuleEngine
{
    public interface IPromoCalculator
    {
        float ApplyPromo(Cart cart);//, Promotion[] promotions);
    }
}