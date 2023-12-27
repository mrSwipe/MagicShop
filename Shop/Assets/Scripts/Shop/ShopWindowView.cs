using System.Collections.Generic;
using Core.Contracts;
using Gold;
using Health;
using Location;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class ShopWindowView : MonoBehaviour
    {
        [SerializeField] private RectTransform contentRoot;
        [SerializeField] private ShopWidgetView itemViewPrefab;
        
        private readonly List<ShopWidgetView> items = new();
        
        private ShopManager shopManager;
        private GoldManager goldManager;
        private HealthManager healthManager;
        private LocationManager locationManager;
        
        [Inject]
        public void Construct(ShopManager shopManagerIn,
            [Inject(Id = nameof(GoldManager))] IManager goldManagerIn, 
            [Inject(Id = nameof(HealthManager))] IManager healthManagerIn, 
            [Inject(Id = nameof(LocationManager))] IManager locationManagerIn)
        {
            shopManager = shopManagerIn;
            
            goldManager = goldManagerIn as GoldManager;
            healthManager = healthManagerIn as HealthManager;
            locationManager = locationManagerIn as LocationManager;
        }
        
        public void Awake()
        {
            goldManager.ChangedGoldValue += OnGoldChangedHandler;
            healthManager.ChangedHealthValue += OnHealthChangedHandler;
            locationManager.ChangedLocation += OnLocationChangedHandler;
            
            foreach (var bundle in shopManager.ShopData)
            {
                var item = ProjectContext.Instance.Container
                    .InstantiatePrefab(itemViewPrefab, contentRoot)
                    .GetComponent<ShopWidgetView>();
                
                item.Init(bundle, UpdateView);
                items.Add(item);
            }
        }

        private void UpdateView()
        {
            if (items is {Count: 0}) return;

            foreach (var item in items)
            {
                item.UpdateBuyButton();
            }
        }
        
        private void OnGoldChangedHandler(int v)
        {
            UpdateView();
        }

        private void OnHealthChangedHandler(int v)
        {
            UpdateView();
        }
        
        private void OnLocationChangedHandler(string l)
        {
            UpdateView();
        }
        
        private void OnDestroy()
        {
            goldManager.ChangedGoldValue -= OnGoldChangedHandler;
            healthManager.ChangedHealthValue -= OnHealthChangedHandler;
            locationManager.ChangedLocation -= OnLocationChangedHandler;
            
            foreach (var item in items)
            {
                Destroy(item.gameObject);
            }
            items.Clear();
        }
    }
}
