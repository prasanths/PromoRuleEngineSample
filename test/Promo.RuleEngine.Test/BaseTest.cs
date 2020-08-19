using Microsoft.Extensions.PlatformAbstractions;
using System;

namespace Promo.RuleEngine.Test
{
    public class BaseTest
    {
        protected BaseTest()
        {
            this.Environment = new ApplicationEnvironment();
        }

        public ApplicationEnvironment Environment { get; set; }
    }
}
