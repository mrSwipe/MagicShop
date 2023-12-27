using Core.Contracts;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Gold
{
    public abstract class BaseGoldReward : IReward
    {
        [OdinSerialize, ShowInInspector]
        public virtual int Amount { get; private set; }
        
    }
}