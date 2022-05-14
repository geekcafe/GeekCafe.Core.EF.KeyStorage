using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekCafe.Core.EF.KeyStorage.MySql;
public class MySqlKeyContext : KeyContext<MySqlKeyContext>,
    IKeyContext, IDataProtectionKeyContext
{

    /// <summary>
    /// Determine if we AutoMigrate or now
    /// </summary>
    public bool AutoMigrate { get; private set; } = true;
    private static volatile bool IsInitialized = false;

    /// <summary>
    ///     The object mutext used for initializing the context.
    /// </summary>
    private static readonly object Mutex = new object();


    public MySqlKeyContext(DbContextOptions<MySqlKeyContext> options)
        : base(options)
    {
        Console.WriteLine($"Initialing {options}");
        Initialize();


    }


    private void Initialize()
    {
        // migrate the db
        Migrate();
    }
    private void Migrate()
    {
        if (!AutoMigrate) return;
        if (IsInitialized) return;


        lock (Mutex)
        {
            if (IsInitialized) return;

            // skip if this is an InMemory Db
            if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                // Migrate database
                Database.Migrate();                
            }
            IsInitialized = true;
        }
    }
}


