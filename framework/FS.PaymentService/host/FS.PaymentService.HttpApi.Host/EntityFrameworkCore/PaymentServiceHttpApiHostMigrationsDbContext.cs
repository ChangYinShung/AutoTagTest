using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.PaymentService.EntityFrameworkCore;

public class PaymentServiceHttpApiHostMigrationsDbContext : AbpDbContext<PaymentServiceHttpApiHostMigrationsDbContext>
{
    public PaymentServiceHttpApiHostMigrationsDbContext(DbContextOptions<PaymentServiceHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigurePaymentService();
    }
}
