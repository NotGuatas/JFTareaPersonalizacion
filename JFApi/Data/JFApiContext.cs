using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JFTareaPersonalizacion.Models;

namespace JFApi.Data
{
    public class JFApiContext : DbContext
    {
        public JFApiContext (DbContextOptions<JFApiContext> options)
            : base(options)
        {
        }

        public DbSet<JFTareaPersonalizacion.Models.JFsuplementos> JFsuplementos { get; set; } = default!;
    }
}
