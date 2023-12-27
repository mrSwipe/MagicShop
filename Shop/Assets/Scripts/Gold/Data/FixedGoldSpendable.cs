using System;
using Sirenix.OdinInspector;

namespace Gold
{
    [ShowInInspector, Serializable]
    public class FixedGoldSpendable : BaseGoldSpendable
    {
        public override int Amount => 10;
    }
}