using System.Linq;

namespace cremeCoffeeBurgett.Models
{
    public class CoffeeshopUnitOfWork : ICoffeeshopUnitOfWork
    {
        private CoffeeshopContext context { get; set; }
        public CoffeeshopUnitOfWork(CoffeeshopContext ctx) => context = ctx;

        private Repository<Bean> beanData;
        public Repository<Bean> Beans {
            get {
                if (beanData == null)
                    beanData = new Repository<Bean>(context);
                return beanData;
            }
        }

        private Repository<Origin> originData;
        public Repository<Origin> Origins {
            get {
                if (originData == null)
                    originData = new Repository<Origin>(context);
                return originData;
            }
        }

        private Repository<CoffeeOrigin> coffeeoriginData;
        public Repository<CoffeeOrigin> CoffeeOrigins {
            get {
                if (coffeeoriginData == null)
                    coffeeoriginData = new Repository<CoffeeOrigin>(context);
                return coffeeoriginData;
            }
        }

        private Repository<Country> countryData;
        public Repository<Country> Countries
        {
            get {
                if (countryData == null)
                    countryData = new Repository<Country>(context);
                return countryData;
            }
        }

        public void DeleteCurrentCoffeeOrigins(Bean bean)
        {
            var currentOrigins = CoffeeOrigins.List(new QueryOptions<CoffeeOrigin> {
                Where = ba => ba.BeanId == bean.BeanId
            });
            foreach (CoffeeOrigin ba in currentOrigins) {
                CoffeeOrigins.Delete(ba);
            }
        }

        public void LoadNewCoffeeOrigins(Bean bean, int[] originids)
        {
            bean.CoffeeOrigins = originids.Select(i =>
                new CoffeeOrigin { Bean = bean, OriginId = i })
                .ToList();
        }

        public void Save() => context.SaveChanges();
    }
}