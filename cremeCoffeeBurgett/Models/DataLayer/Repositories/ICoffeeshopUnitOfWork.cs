namespace cremeCoffeeBurgett.Models
{
    public interface ICoffeeshopUnitOfWork
    {
        Repository<Bean> Beans { get; }
        Repository<Origin> Origins { get; }
        Repository<CoffeeOrigin> CoffeeOrigins { get; }
        Repository<Country> Countries { get; }

        void DeleteCurrentCoffeeOrigins(Bean bean);
        void LoadNewCoffeeOrigins(Bean bean, int[] authorids);
        void Save();
    }
}
