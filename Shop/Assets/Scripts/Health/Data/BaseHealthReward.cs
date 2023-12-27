using Core.Contracts;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Health
{
    public class BaseHealthReward : IReward
    {
        [OdinSerialize, HideInInspector]
        protected int amount;
            
        [ShowInInspector] 
        public virtual int Amount
        {
            get => amount;
            protected set => amount = value;
        }
    }
}