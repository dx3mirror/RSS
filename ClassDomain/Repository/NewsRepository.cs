using ClassEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDomain.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _context;

        public NewsRepository(NewsContext context) => _context = context;

        public async Task<IEnumerable<News>> GetAllNews()
        {
            try
            {
                return await _context.News.ToListAsync();
            }
            catch (Exception ex)
            {
                // Обработка исключения
                // Здесь может быть логирование или другие действия в случае ошибки
                throw new Exception("Ошибка при получении всех новостей.", ex);
            }
        }

        public async Task<News?> GetNewsById(int? id)
        {
            try
            {
                return await _context.News.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Обработка исключения
                throw new Exception($"Ошибка при получении новости с Id = {id}.", ex);
            }
        }

        public async Task AddNews(News news)
        {
            try
            {
                _context.News.Add(news);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Обработка исключения
                throw new Exception("Ошибка при добавлении новости.", ex);
            }
        }
    }
}
