using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShortUrl.Data;
using ShortUrl.Models;
using ShortUrl.Services;

namespace ShortUrl.Controllers
{
    [ApiController]
    [Route("")]
    public class ShortenController : ControllerBase
    {
        private readonly ILogger<ShortenController> _logger;
        private readonly DatabaseContext _context;

        public ShortenController(ILogger<ShortenController> logger, DatabaseContext context)
        {
            _logger = logger;

            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl(CreateUrl url)
        {
            try
            {
                // Validate url request
                if (url == null | !CheckURLValid(url.Url))
                    return Ok(url.Url);

                // Check if Url has already been registerd
                var shortendUrl = await _context.ShortendUrls
                    .FirstOrDefaultAsync(x => x.Url == url.Url);
                
                if (shortendUrl == null)
                {
                    string token = ShortLink.GenerateShortUrl();
                    
                    // No duplicates
                    do
                    {
                        token = ShortLink.GenerateShortUrl();

                        shortendUrl = await _context.ShortendUrls
                            .FirstOrDefaultAsync(x => x.UrlId == token);
                    }
                    while (shortendUrl != null);

                    shortendUrl = new ShortendUrl
                    {
                        Url = url.Url,
                        UrlId = token
                    };

                    await _context.ShortendUrls.AddAsync(shortendUrl);    
                    await _context.SaveChangesAsync();
                }
            
                return Ok($"{Request.Scheme}://{Request.Host}/{shortendUrl.UrlId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong instide the CreateUrl action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{urlId}")]
        public async Task<IActionResult> Redirect(string urlId)
        {
            try
            {
                // Find Url from Id
                var shortendUrl = await _context.ShortendUrls
                    .FirstOrDefaultAsync(x => x.UrlId == urlId);
                
                // Do nothing if cannot find url
                if (shortendUrl == null)
                    return Ok("Cannot proccess request");

                // Redirect
                return RedirectPreserveMethod(shortendUrl.Url);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong instide the Redirect action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
            
        /// <summary>
        /// Validate Url
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool CheckURLValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) 
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
