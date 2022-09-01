namespace ACMEWebApi.Data
{
    public class DbInitializer
    {
        private readonly DataContext _context;

        public DbInitializer(DataContext context)
        {
            _context = context;
        }

        public void Run()
        {

        }
    }
}
