using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntity
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options) { }

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasData(
                new News
                {
                    NewsId = 1,
                    Title = "Пример новости 1",
                    Content = "Содержание новости 1",
                    Source = "Источник 1",
                    PublicationDate = DateTime.Now.AddDays(-1)
                },
                new News
                {
                    NewsId = 2,
                    Title = "Пример новости 2",
                    Content = "Содержание новости 2",
                    Source = "Источник 2",
                    PublicationDate = DateTime.Now.AddDays(-2)
                }
            // Добавьте свои примеры новостей по мере необходимости
            );
        }
    }
}
