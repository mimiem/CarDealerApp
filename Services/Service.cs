namespace Services
{
    using CarDealer.Data;

    public abstract class Service
    {
        public Service()
        {
            this.context = Data.Context;
        }
        protected CarDealerContext context { get; }
    }
}
