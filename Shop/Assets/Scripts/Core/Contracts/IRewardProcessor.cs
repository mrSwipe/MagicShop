namespace Core.Contracts
{
    public interface IRewardProcessor
    {
        bool CanReward();
        void Reward();
    }
}