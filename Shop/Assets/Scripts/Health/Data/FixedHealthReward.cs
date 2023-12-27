using System;
using Sirenix.OdinInspector;

namespace Health
{
    [ShowInInspector, Serializable]
    public class FixedHealthReward : BaseHealthReward
    {
        public override int Amount => 10;
    }
}