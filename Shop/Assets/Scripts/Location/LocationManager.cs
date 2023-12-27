using System;
using Core.Contracts;

namespace Location
{
    public class LocationManager : IManager
    {
        private const string StartLocation = "Home";
        
        public event Action<string> ChangedLocation;

        private string _location = StartLocation;

        public string Location
        {
            get => _location;
            set
            {
                if (_location == value) return;
                _location = value;
                ChangedLocation?.Invoke(_location);
            }
        }

        public bool CanSpend(ISpendable s)
        {
            return false;
        }

        public void Spend(ISpendable s)
        {
        }

        public bool CanReward(IReward r)
        {
            return !string.Equals(Location, ((LocationReward) r).LocationName, StringComparison.InvariantCulture);
        }

        public void Reward(IReward r)
        {
            ChangeLocation(((LocationReward) r).LocationName);
        }

        public void BackHome()
        {
            ChangeLocation(StartLocation);
        }
        
        private void ChangeLocation(string newLocation)
        {
            Location = newLocation; 
        }
    }
}