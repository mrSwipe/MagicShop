namespace Core.Contracts
{
    public interface ISpendableProcessor
    {
        bool CanSpend();
        void Spend();
    }
}