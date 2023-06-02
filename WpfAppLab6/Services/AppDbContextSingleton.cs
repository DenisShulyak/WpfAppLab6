using Microsoft.EntityFrameworkCore;
using WpfAppLAb6.Data;

namespace WpfAppLab6.Services
{
    public class AppDbContextSingleton
    {
        private static ApplicationDbContext _instance;
        private static readonly object _lock = new object();

        public static ApplicationDbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            // Pass the required parameter to the AppDbContext constructor
                            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseNpgsql("Host=localhost;Port=5432;Database=lab6testdb;Username=postgres;Password=root;")
                                .Options;
                            _instance = new ApplicationDbContext(options);
                        }
                    }
                }
                return _instance;
            }
        }
    }

}