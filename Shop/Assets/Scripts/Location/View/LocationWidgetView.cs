using Core.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Location
{
    public class LocationWidgetView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button button;
        
        private LocationManager locationManager;

        [Inject]
        private void Construct([Inject(Id = nameof(LocationManager))] IManager locationManagerIn)
        {
            locationManager = locationManagerIn as LocationManager;
        }
        
        private void OnEnable()
        {
            button.onClick.AddListener(ButtonClick);
            locationManager.ChangedLocation += Location;
            
            Location(locationManager.Location);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(ButtonClick);
            locationManager.ChangedLocation -= Location;
        }

        private void Location(string locationName)
        {
            text.text = locationName;
        }
        
        private void ButtonClick()
        {
            locationManager.BackHome();
        }
    }
}