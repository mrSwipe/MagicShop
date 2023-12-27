using System;
using Sirenix.OdinInspector;

namespace Health
{
    [ShowInInspector, Serializable]
    public class FixedHealthSpendable : BaseHealthSpendable
    {
        public override int Amount => 10;
    }
}