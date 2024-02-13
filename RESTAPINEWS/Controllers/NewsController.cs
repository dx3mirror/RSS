using ClassDomain.Repository;
using ClassEntity;
using Microsoft.AspNetCore.Mvc;

namespace RESTAPINEWS.Controllers
{
    // Контроллер для работы с новостями
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetAllNews()
        {
            var allNews = await _newsRepository.GetAllNews();
            return Ok(allNews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNewsById(int id)
        {
            var news = await _newsRepository.GetNewsById(id);

            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }
    }
}
