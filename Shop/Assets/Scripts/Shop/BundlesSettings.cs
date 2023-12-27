using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu( fileName = "BundlesSettings", menuName = "BundlesSettings" )]
    public class BundlesSettings : SerializedScriptableObject
    {
        [OdinSerialize, ShowInInspector] 
        private List<BundleData> bundles = new();
        
        public IReadOnlyList<BundleData> Bundles => bundles;
    }
}