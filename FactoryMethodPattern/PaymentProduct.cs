namespace FactoryMethodPattern
{
    // Product
    public abstract class PaymentProduct
    {
        protected string _description { get; set; }
        protected string _type { get; set; }

        public abstract void Pay(double value);
    }
}