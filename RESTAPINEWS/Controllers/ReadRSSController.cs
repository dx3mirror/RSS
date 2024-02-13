using ClassDomain.Repository;
using ClassEntity;
using CodeHollow.FeedReader;
using Microsoft.AspNetCore.Mvc;

namespace RESTAPINEWS.Controllers
{
    // Контроллер для работы с RSS
    [ApiController]
    [Route("api/rss")]
    public class RssController : ControllerBase
    {
        private readonly IRSSRepository _newsRepository;

        public RssController(IRSSRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpPost("read")]
        public async Task<ActionResult<IEnumerable<News>>> ReadRss([FromBody] string rssUrl)
        {
            var feed = await FeedReader.ReadAsync(rssUrl);

            var newsList = feed.Items.Select(item => new News
            {
                Title = item.Title,
                Content = item.Description,
                Source = rssUrl,
                PublicationDate = item.PublishingDate ?? DateTime.UtcNow
            }).ToList();

            await _newsRepository.AddRangeNews(newsList);

            return Ok(newsList);
        }
    }
}
