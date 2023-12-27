using System;
using Core.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopWidgetView : MonoBehaviour
    {
        [SerializeField] private TMP_Text bundleName;
        [SerializeField] private Button buyButton;
        
        private ISpendableProcessor spendable; 
        private IRewardProcessor reward;
        private Action onButtonClick;
        
        public void Init(ShopData data, Action onButtonClickCallback)
        {
            bundleName.text = data.BundleName;
            spendable = data.SpendableProcessor;
            reward = data.RewardProcessor;
            onButtonClick = onButtonClickCallback;
            
            UpdateBuyButton();
        }

        public void UpdateBuyButton()
        {
            buyButton.interactable = spendable.CanSpend() && reward.CanReward();
        }
        
        private void Awake()
        {
            buyButton.onClick.AddListener(BuyClick);
        }
        
        private void OnDestroy()
        {
            buyButton.onClick.RemoveAllListeners();
        }
        
        private void BuyClick()
        {
            spendable.Spend();
            reward.Reward();
            
            onButtonClick?.Invoke();
        }
    }
}