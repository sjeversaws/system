using Microsoft.EntityFrameworkCore;

namespace SystemA_API.Data;

public class DataContext : DbContext
{
    public DbSet<DataPoint> DataPoints { get; set; }
    
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}

public class DataPoint
{
    public string Id { get; set; }
    public string Value { get; set; }
}