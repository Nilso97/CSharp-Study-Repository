namespace FactoryMethodPattern
{
    // Concrete Product
    public class InternationalPurchasePayment : PaymentProduct
    {
        public InternationalPurchasePayment()
        {
            this._description = "Compra na Amazon";
            this._type = "Cartão de Crédito";
        }

        public override void Pay(double value)
        {
            Console.WriteLine(
                $"A conta [{this._description}] foi paga via {this._type}, no valor de ${value} dólares."
            );
        }
    }
}