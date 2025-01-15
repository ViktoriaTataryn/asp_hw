using ht8.Models;
using Microsoft.EntityFrameworkCore;

namespace ht8.Data;

public class DataContext :DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Film> Films { get; set; }
    public DbSet<Author> Authors { get; set; }
}

