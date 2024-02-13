using ClassEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDomain.Repository
{
    public interface IRSSRepository
    {
        Task<IEnumerable<News>> GetAllNews();
        Task<News?> GetNewsById(int? id);
        Task AddNews(News news);
        Task AddRangeNews(IEnumerable<News> newsList);
    }
}
