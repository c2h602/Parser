using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// отвечает за настройки парсера

namespace Parser.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; } // хранится url сайта

        string Prefix { get; set; } //
                                    
        int StartPoint { get; set; } // указывает с какой страницы будут парсится данные

        int EndPoint { get; set; } // конечный индекс страницы для парсинга
    }
}
