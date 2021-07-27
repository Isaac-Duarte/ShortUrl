using System;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;

namespace ShortUrl.Services
{
    public static class ShortLink
    {
        /// <summary>
        /// Generate random token
        /// </summary>
        /// <returns></returns>
        public static string GenerateShortUrl()
        {
            string urlsafe = string.Empty;
            Random rand = new Random();

            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => rand.Next())
              .ToList()
              .ForEach(i => urlsafe += Convert.ToChar(i));

            var endIndex = rand.Next(2, 7);
            var startIndex = rand.Next(0, urlsafe.Length - endIndex);
            
            string token = urlsafe.Substring(startIndex, endIndex);

            return token;

        }

    }
}