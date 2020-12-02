using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Data.Api
{
    public class ProyectoFinalContext : DbContext
    {
        public DbSet<Persona> Personas {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ProyectoFinal;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"workstation id=ProyectoApi.mssql.somee.com;packet size=4096;user id=ivog_SQLLogin_1;pwd=jn9k3qdwbm;data source=ProyectoApi.mssql.somee.com;persist security info=False;initial catalog=ProyectoApi");

        }
    }
}
