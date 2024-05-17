using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultiShop.Discount.Context;

public class DapperContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = ALIERENKAYHAN\\MSSQLSERVER01;Initial Catalog = MultiShopDiscountDb;Integrated Security=true;Encrypt=False");
    }

    public DbSet<Coupon> Coupons { get; set; }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
