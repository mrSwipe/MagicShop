using Core.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gold
{
    public class GoldWidgetView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button addButton;
        [SerializeField] private Button takeButton;

        private GoldManager goldManager;

        [Inject]
        private void Construct([Inject(Id = nameof(GoldManager))] IManager goldManagerIn)
        {
            goldManager = goldManagerIn as GoldManager;
        }

        private void OnEnable()
        {
            addButton.onClick.AddListener(AddButtonClick);
            takeButton.onClick.AddListener(TakeButtonClick);
            
            goldManager.ChangedGoldValue += GoldValue;
            
            GoldValue(goldManager.Gold);
        }

        private void OnDisable()
        {
            addButton.onClick.RemoveListener(AddButtonClick);
            takeButton.onClick.RemoveListener(TakeButtonClick);
            
            goldManager.ChangedGoldValue -= GoldValue;
        }

        private void GoldValue(int gold)
        {
            text.text = $"$ {gold}";
        }
        
        private void AddButtonClick()
        {
            goldManager.AddGold(100);
        }
        
        private void TakeButtonClick()
        {
            goldManager.SpendGold(100);
        }
    }
}