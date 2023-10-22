using Parser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Habr
{
    class HabrSettings : IParserSettings
    {
        public HabrSettings(int start, int end) // в конструкторе будет принимать значения границ парсинга
        {
            StartPoint= start;
            EndPoint= end;
        } 
        public string BaseUrl { get; set; } = "https://habr.com/ru";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
