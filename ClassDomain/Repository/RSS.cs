using ClassEntity;
using Microsoft.EntityFrameworkCore;


namespace ClassDomain.Repository
{
    public class RSS : IRSSRepository
    {
        private readonly NewsContext _context;

        public RSS(NewsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            try
            {
                return await _context.News.ToListAsync();
            }
            catch (Exception ex)
            {
                // Обработка исключения
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

        public async Task AddRangeNews(IEnumerable<News> newsList)
        {
            try
            {
                _context.News.AddRange(newsList);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Обработка исключения
                throw new Exception("Ошибка при добавлении списка новостей.", ex);
            }
        }

    }
}
