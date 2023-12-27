using System;
using Core.Contracts;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Shop
{
    [ShowInInspector, Serializable]
    public sealed class BundleData
    {
        [OdinSerialize, ShowInInspector] private string bundleName;
        
        [ShowInInspector] public ISpendable Spend;
        [ShowInInspector] public IReward Reward;
        
        public string BundleName => bundleName;
    }
}


