using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JFTareaPersonalizacion.Models;

namespace JFTareaPersonalizacion.Data
{
    public class JFTareaPersonalizacionContext : DbContext
    {
        public JFTareaPersonalizacionContext (DbContextOptions<JFTareaPersonalizacionContext> options)
            : base(options)
        {
        }

        public DbSet<JFTareaPersonalizacion.Models.JFsuplementos> JFsuplementos { get; set; } = default!;
    }
}
