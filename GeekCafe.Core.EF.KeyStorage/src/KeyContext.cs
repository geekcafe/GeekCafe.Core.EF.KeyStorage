using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekCafe.Core.EF.KeyStorage;
public abstract class KeyContext<T> : DbContext, IDataProtectionKeyContext,
    IKeyContext where T : KeyContext<T>
{

    // A recommended constructor overload when using EF Core 
    // with dependency injection.
    public KeyContext(DbContextOptions<T> options)
        : base(options) {        
    }

    // This maps to the table that stores keys.
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = default!;

    
}

public interface IKeyContext: IDisposable
{
    DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
}

