namespace FactoryMethodPattern
{
    public class ConcreteCreator : Creator
    {
        public override PaymentProduct FactoryMethod()
        {
            return new InternationalPurchasePayment();
        }
    }
}