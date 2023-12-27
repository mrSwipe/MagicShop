using Core.Contracts;

namespace Core
{
    public class RewardProcessor : IRewardProcessor
    {
        private readonly  IManager manager;
        private readonly IReward reward;
        
        public RewardProcessor(IManager managerIn, IReward rewardIn)
        {
            manager = managerIn;
            reward = rewardIn;
        }
        
        public bool CanReward()
        {
            return manager.CanReward(reward);
        }

        public void Reward()
        {
            manager.Reward(reward);
        }
    }
}