using System;
using Core.Contracts;

namespace Gold
{
    public class GoldManager : IManager
    {
        private const int StartGold = 1000;
        
        public event Action<int> ChangedGoldValue;

        private int _gold = StartGold;
        
        public int Gold
        {
            get => _gold;
            private set
            {
                var prevValue = _gold;
                _gold = Math.Max(0, value);
                if (prevValue != _gold)
                {
                    ChangedGoldValue?.Invoke(_gold);
                }
            }
        } 
        
        public void AddGold(int delta)
        {
            Gold += delta;
        }
        
        public void SpendGold(int delta)
        {
            Gold -= delta;
        }
        
        public bool CanSpend(ISpendable s)
        {
            if (Gold <= 0) return false;
            
            var amount = ((BaseGoldSpendable) s).Amount;
            return Gold - amount >= 0;
        }
        
        public void Spend(ISpendable s)
        {
            if (!CanSpend(s)) return;

            var amount = ((BaseGoldSpendable) s).Amount;
            SpendGold(amount);
        }

        public bool CanReward(IReward r)
        {
            return true;
        }

        public void Reward(IReward r)
        {
            var amount = ((BaseGoldReward) r).Amount;
            AddGold(amount);
        }
    }
}