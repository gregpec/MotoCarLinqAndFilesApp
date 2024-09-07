using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoAppmod4App.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MotoAppmod4App.Data.Entities;
//using MotoAppmod4App.Enities;

public class MotoAppmod4AppDbContext : DbContext
{
    //public DbSet<Employee> Employees => Set<Employee>();

    //Employee -zasób
    // = ustawiony metodą Set, która znajduję się w tym kontekscie DbContext
   // public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    // dodanie overrida na metode onconfiguring
    {
        base.OnConfiguring(optionsBuilder); // automatycznie zapisuje

        // ojreslenie jak będzie się nazywała nasza baza w pamieci
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");



    }
}

