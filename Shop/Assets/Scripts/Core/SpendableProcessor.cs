using Core.Contracts;

namespace Core
{
    public class SpendableProcessor : ISpendableProcessor
    {
        private readonly IManager manager;
        private readonly ISpendable spendable;
        
        public SpendableProcessor(IManager managerIn, ISpendable spendableIn)
        {
            manager = managerIn;
            spendable = spendableIn;
        }
        
        public bool CanSpend()
        {
            return manager.CanSpend(spendable);
        }

        public void Spend()
        {
            manager.Spend(spendable);
        }
    }
}