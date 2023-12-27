using System;
using Core;
using Sirenix.OdinInspector;

namespace Health
{
    [ShowInInspector, Serializable]
    public class PercentHealthReward : BaseHealthReward
    {
        [ShowInInspector] 
        public override int Amount
        {
            get => amount;
            protected set => amount = value.PercentRange();
        }
    }
}