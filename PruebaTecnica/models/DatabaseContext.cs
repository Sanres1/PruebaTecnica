using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Options;

namespace PruebaTecnica.models
{
    //Creamos el contexto de la base de datos
    class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //le damos al contexto el string de conexión
            //**IMPORTANTE**
            //recordar comandos para hacer la migración en la consola de administración nugets
            //ADD-Migration -nombre-
            //Update-Database
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DCDSIOV\\SQLEXPRESS;Initial Catalog=PruebaTecnicaSantiago;Integrated Security=True")
                .EnableSensitiveDataLogging(true);
               
        }


        public DbSet<Empresa> Empresas { get; set; }
        
        
    }
}
