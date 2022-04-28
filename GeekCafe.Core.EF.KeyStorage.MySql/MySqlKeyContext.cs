using Microsoft.EntityFrameworkCore;

namespace GeekCafe.Core.EF.KeyStorage.MySql;
public class MySqlKeyContext : GeekCafe.Core.EF.KeyStorage.KeyContext<MySqlKeyContext>, IKeyContext
{
    public MySqlKeyContext(DbContextOptions<MySqlKeyContext> options)
        : base(options) {

    }
    

}

