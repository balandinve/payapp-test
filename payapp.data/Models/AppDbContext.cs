using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace payapp.data.Models
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// Операции со счетом клиентов
        /// </summary>
        public DbSet<ClientOperation> ClientOperations { get; set; }
    }
}
