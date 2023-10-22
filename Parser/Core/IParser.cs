using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parser.Core
{
    interface IParser<T> where T : class // обобщенный интерфейс, это значит, что классы, которые будут реализовывать его, смогут возвращать данные любого ссылочного типа
    {
        T Parse(IHtmlDocument document); // метод с типом Т - этот тип, при реализации в классе, будет заменяться на любой другой тип Parse
                                         // приимает в аргументы объект типа IHtmlDocument
    }
}
