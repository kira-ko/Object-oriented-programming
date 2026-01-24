namespace Lab3FoodDelivery.State
{
    public interface IOrderState
    {
        void Process();
        void Cancel();
        void MarkAsDelivered();
        string GetStatus();
    }
}
