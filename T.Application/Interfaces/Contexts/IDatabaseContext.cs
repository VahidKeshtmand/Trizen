using Microsoft.EntityFrameworkCore;
using T.Domain;

namespace OS.Application.Interfaces.Contexts
{
    /*دلیل اینکه داریم از IDatabaseContext استفاده می کنیم اینه که ما نیاز داریم از Context در لایه Application
     استفاده کنیم ولی Context در لایه بالاتر است و نمی تونیم در Application که لایه ی پایین تری است استفاده کنیم.
    به همین دلیل میایم از یک interface استفاده می کنیم.*/
    public interface IDatabaseContext
    {
        /*این متد در DbContext پیاده سازی شده است و نیازی به پیاده سازی توسط DatabaseContext نیست.
         برای اینکه ما بتوانیم از SaveChanges در لایه Application استفاده کنیم مجبوریم این متد را اینجا بنویسیم.
        که چهارتا پیاده سازی مختلف داره.*/
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken());
    }
}
