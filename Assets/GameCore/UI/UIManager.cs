using GameCore.ScriptableObjects;
using UnityEngine;
using VContainer;

namespace GameCore.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private AssetRefs _assetRefs;
        
        [Inject]
        private void Construct(AssetRefs assetRefs)
        {
            _assetRefs = assetRefs;
        }
    }
}
