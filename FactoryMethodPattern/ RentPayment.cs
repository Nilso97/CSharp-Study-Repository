namespace FactoryMethodPattern
{
    // Concrete Product
    public class RentPayment : PaymentProduct
    {
        public  RentPayment()
        {
            this._description = "Pagamento de aluguel";
            this._type = "PIX";
        }
        
        public override void Pay(double value)
        {
            Console.WriteLine(
                $"A conta [{this._description}] foi paga via {this._type}, no valor de R${value}."
            );
        }
    }
}