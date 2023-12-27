namespace Core.Contracts
{
    public interface IManager
    {
        bool CanSpend(ISpendable s);
        void Spend(ISpendable s);
        
        bool CanReward(IReward r);
        void Reward(IReward r);
    }
}