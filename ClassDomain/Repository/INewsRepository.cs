using ClassEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDomain.Repository
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllNews();
        Task<News?> GetNewsById(int? id);
        Task AddNews(News news);
    }
}
