using FactoryMethodPattern;

namespace FactoryMethod
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Creator creator = new ConcreteCreator();

            var payment = creator.FactoryMethod();

            payment.Pay(250.00);
        }
    }
}