using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synonyms.ViewModel
{
    public class SynonymDtoViewModel
    {
        public virtual string Term { get; set; }
        public virtual List<string> Synonyms { get; set; }

    }
}