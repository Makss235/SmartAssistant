using SmartAssistant.Data.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data.WordsData
{
    public class Words : BaseData<List<WordsObj>>
    {
        public Words() : base("ru", "Words") { }
    }
}
