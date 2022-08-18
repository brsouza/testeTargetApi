using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testeTargetAPI.Models.Usuario
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options)
          : base(options)
        { }

        public DbSet<Usuario> usuarios { get; set; }
    }


}
