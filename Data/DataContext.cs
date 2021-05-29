using Microsoft.EntityFrameworkCore;
using Shop1.Models;

namespace Shop1.Data{
    // dbcontext representação do banco
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)  {

    }   
 //db set representação das tabelas
    public DbSet<Product> Product {get; set;}

    public DbSet<Category> Category {get; set;}

    public DbSet<User> User {get; set;}


}


}
