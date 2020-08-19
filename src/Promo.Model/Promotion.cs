using System;

namespace Promo.Model
{
    public class Promotion
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public Item[] ItemsInvolved { get; set; }
        public float Price { get; set; }
    }
}
