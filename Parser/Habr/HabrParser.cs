using AngleSharp.Html.Dom;
using Parser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Habr
{
    class HabrParser : IParser<string[]> // реализуем интерфейс IParser с типом массива стрингов
    {
        public string[] Parse(IHtmlDocument document) // по сути, тут мы получаем коллецию заголовков статей
        {
            var list = new List<string>(); // создание коллекции

            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("tm-title__link"));
            // при помощи объекта document и метода QuerySelectorAll мы можем получить из html документа теги опредленного типа ("a" - ссылка)
            // далее при помощи метода Where из всех элементов тега "а" нам нужно убедиться, что у элемента присутствует свойство class,
            // и что он должен содержать значение "tm-title__link"
            // у каждого объекта, реализующего "а"-элемент из AngleSharp есть свойство TextContent, в нем содержится заголовок статьи
            foreach ( var item in items ) 
            {
                list.Add(item.TextContent); // добавление в коллекцию
            }

            return list.ToArray();
        }
    }
}
