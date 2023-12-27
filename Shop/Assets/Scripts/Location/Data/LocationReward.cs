using System;
using Core.Contracts;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Location
{
    [ShowInInspector, Serializable]
    public class LocationReward : IReward
    {
        [OdinSerialize, ShowInInspector]
        public string LocationName { get; private set; }
    }
}