using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    // Назначение этого класса - загружать исходный код страницы из указанных настроек парсера
    internal class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}/";
        }

        public async Task<string> GetSourceByPageId(int id) // id страницы в аргументе
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString()); // редактируем url для запроса
            var response = await client.GetAsync(currentUrl);
            string source = null; // в ней мы будем получать исходный код страницы

            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
            
        }
    }
}
