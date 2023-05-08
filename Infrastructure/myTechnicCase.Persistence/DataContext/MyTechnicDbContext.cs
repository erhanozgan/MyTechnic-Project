using Microsoft.EntityFrameworkCore;
using myTechnicCase.Domain.Entity;
using myTechnicCase.Persistence.EntityConfigurations;
namespace myTechnicCase.Persistence.DataContext;

public class MyTechnicDbContext : DbContext
{
    public MyTechnicDbContext(DbContextOptions<MyTechnicDbContext> options) : base(options)
    {

    }

    public DbSet<Personnel> Personnels { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonnelConfiguration).Assembly);

        modelBuilder.Entity<Personnel>().HasData(new List<Personnel>
        {
            new() { Id = 12, Name = "Erhan", Surname = "OZGAN", Active = true, Address = "Maltepe/Istanbul", Email = "erhanozgan@gmail.com", PersonnelCode = 337, Phone = "+905534535452", UserName = "erhanozgan", Title = "Dr"},
            new() { Id = 21, Name = "Derya", Surname = "SEFEROGLU", Active = true, Address = "Kartal/Istanbul", Email = "deryasef@gmail.com", PersonnelCode = 112, Phone = "+905533334455", UserName = "deryasef", Title = "Op.Dr"},
            new() { Id = 31, Name = "Alya", Surname = "OZGAN", Active = true, Address = "Sariyer/Istanbul", Email = "alyaozgan@gmail.com", PersonnelCode = 123, Phone = "+905324456767", UserName = "alyaozgan", Title = "Student"},
            new() { Id = 41, Name = "Ekrem", Surname = "DEMIR", Active = true, Address = "Alsancak/Izmir", Email = "ekremdemir@gmail.com", PersonnelCode = 887, Phone = "+05543431212", UserName = "ekremdemir", Title = "Controller"}
        });
        modelBuilder.Entity<Team>().HasData(new List<Team>()
        {
            new() {Id = 1, Name = "A Team", SupervisorPersonnelId = 12},
            new() {Id = 2, Name = "B Team", SupervisorPersonnelId = 21},
            new() {Id = 3, Name = "C Team", SupervisorPersonnelId = 31}
        });
        modelBuilder.Entity<Shift>().HasData(new List<Shift>()
        {
            new() {Id = 111, Name = "Morning Shift", Type = "Half Time", StartDate = new DateTime(2023, 6, 15), EndDate =new DateTime(2023, 7, 15), TeamId = 1},
            new() {Id = 222, Name = "Night Shift", Type = "Full Time", StartDate = new DateTime(2023, 7, 17), EndDate =new DateTime(2023, 8, 18), TeamId = 2}

        });
    }
}