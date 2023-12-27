using System;
using Core;
using Core.Contracts;

namespace Health
{
    public class HealthManager : IManager
    {
        private const int StartHealth = 100;
        
        public event Action<int> ChangedHealthValue;

        private int _health = StartHealth;
        
        public int Health
        {
            get => _health;
            private set
            {
                var prevValue = _health;
                _health = value.MinMaxRange(StartHealth);
                if (prevValue != _health)
                {
                    ChangedHealthValue?.Invoke(_health);
                }
            }
        }

        private int MaxHealth => StartHealth;
        
        public void AddHealth(int delta)
        {
            Health += delta;
        }
        
        public void TakeHealth(int delta)
        {
            Health -= delta;
        }

        public bool CanSpend(ISpendable s)
        {
            if (Health <= 0) return false;
            
            switch (s)
            {
                case PercentHealthSpendable percentHealthSpendable:
                    var healthAmountByPercent = (float)percentHealthSpendable.Amount / 100 * Health;
                    return Health - healthAmountByPercent >= 0;
                
                case HealthSpendable healthSpendable:
                    return Health - healthSpendable.Amount >= 0;
                
                case FixedHealthSpendable fixedHealthSpendable:
                    return Health - fixedHealthSpendable.Amount >= 0;
            }

            return false;
        }

        public void Spend(ISpendable s)
        {
            if (!CanSpend(s))
            {
                return;
            }

            switch (s)
            {
                case PercentHealthSpendable percentHealthSpendable:
                    var healthAmountByPercent = (float)percentHealthSpendable.Amount / 100 * Health;
                    TakeHealth((int)healthAmountByPercent);
                    break;
                
                case HealthSpendable healthSpendable:
                    TakeHealth(healthSpendable.Amount);
                    break;
                
                case FixedHealthSpendable fixedHealthSpendable:
                    TakeHealth(fixedHealthSpendable.Amount);
                    break;
            }
        }

        public bool CanReward(IReward r)
        {
            return Health > 0 && Health < MaxHealth;
        }

        public void Reward(IReward r)
        {
            if (!CanReward(r)) return;

            switch (r)
            {
                case PercentHealthReward percentHealthReward:
                    var healthAmountByPercent = (float)percentHealthReward.Amount / 100 * Health;
                    AddHealth((int)healthAmountByPercent);
                    break;
                
                case HealthReward healthReward:
                    AddHealth(healthReward.Amount);
                    break;
                
                case FixedHealthReward fixedHealthReward:
                    AddHealth(fixedHealthReward.Amount);
                    break;
            }
        }
    }
}