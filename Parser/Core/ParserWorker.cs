using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser; // поле parser с обобщенным типом IParser          ??зачем оно нужно??
        IParserSettings parserSettings;

        HtmlLoader loader;

        bool isActive; // для контроля класса

        public event Action<object, T> OnNewData; // готовый диллегат(ссылкм на методы) Action, Это событие будет возвращать спаршенные за иттервцию данные, входные и выходные параметры
        public event Action<object> OnCompleted; // информирование при завершении работы парсера

        // публичные свойства
        #region Properties 

        public IParser<T> Parser { get { return parser; } set { parser = value; } }

        public IParserSettings Settings 
        {  
            get 
            { 
                return parserSettings; 
            } 
            set 
            { 
                parserSettings = value;
                loader = new HtmlLoader(value); // создаем экземпляр с новыми настройками парсера
            } 
        }

        public bool IsActive { get { return isActive; } }



        #endregion
        public ParserWorker(IParser<T> parser) // конструктор, реализующий интерфейс IParser
        {
            this.parser = parser; // присваиваем значение аргумента полю
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }
        
        // методы для старта и остановки парсера
        public void Start()
        {
            isActive= true;
            Worker();
        }

        public void Stop()
        {
            isActive = false;
        }

        // метод, котролирующий процесс парсинга
        private async void Worker()
        {
            for(int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageId(i)!; // исходный код страницы с индексом из цикла
                var domParser = new HtmlParser(); // создаем парсер, доступный из AngleSharp

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);

                OnNewData?.Invoke(this, result); // передаем ссылку и результат 
            }

            OnCompleted?.Invoke(this);
            isActive = false;


        }
        


    }
}
