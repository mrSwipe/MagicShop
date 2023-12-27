using Core.Contracts;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Gold
{
    public abstract class BaseGoldSpendable : ISpendable
    {
        [ShowInInspector, OdinSerialize]
        public virtual int Amount { get; private set; }
    }
}