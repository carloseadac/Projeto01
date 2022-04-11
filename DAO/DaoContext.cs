namespace DAO;
public class DaoContext
{
    public DbSet<Address> address { get; set; }
    public DbSet<Client> clients { get; set; }
    public DbSet<Owner> owners { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Purchase> purchases { get; set; }
    public DbSet<Stocks> stocks { get; set; }
    public DbSet<Store> stores { get; set; }
    public DbSet<WishList> wishLists { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
    //https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
    //https://docs.microsoft.com/pt-br/ef/ef6/modeling/code-first/data-annotations
}
