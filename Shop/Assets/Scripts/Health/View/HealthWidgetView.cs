using Core.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Health
{
    public class HealthWidgetView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button addButton;
        [SerializeField] private Button takeButton;
        [SerializeField] private UnityEvent onCheatClickEvent;

        private HealthManager healthManager;

        [Inject]
        private void Construct([Inject(Id = nameof(HealthManager))] IManager healthManagerIn)
        {
            healthManager = healthManagerIn as HealthManager;
        }
        
        private void OnEnable()
        {
            addButton.onClick.AddListener(AddButtonClick);
            takeButton.onClick.AddListener(TakeButtonClick);
            
            healthManager.ChangedHealthValue += HealthValue;
            
            HealthValue(healthManager.Health);
        }

        private void OnDisable()
        {
            addButton.onClick.RemoveListener(AddButtonClick);
            takeButton.onClick.RemoveListener(TakeButtonClick);
            
            healthManager.ChangedHealthValue -= HealthValue;
        }

        private void HealthValue(int health)
        {
            text.text = $"{health}";
        }
        
        private void AddButtonClick()
        {
            healthManager.AddHealth(10);
            onCheatClickEvent?.Invoke();
        }
        
        private void TakeButtonClick()
        {
            healthManager.TakeHealth(10);
            onCheatClickEvent?.Invoke();
        }
    }
}