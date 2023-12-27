using System;
using Sirenix.OdinInspector;

namespace Gold
{
    [ShowInInspector, Serializable]
    public class FixedGoldReward : BaseGoldReward
    {
        public override int Amount => 10;
    }
}