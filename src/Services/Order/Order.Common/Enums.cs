namespace Order.Common
{
    public class Enums
    {
        public enum OrderStatus
        {
            Canceled,
            Pending,
            Approved
        }

        public enum OrderPayment
        {
            CreditCard,
            PayPal,
            BankTransfer
        }
                
    }
}
