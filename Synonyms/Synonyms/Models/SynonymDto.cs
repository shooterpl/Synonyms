using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synonyms.Models
{
    public class SynonymDto
    {
        public int Id { get; set; }
        public virtual string Term { get; set; }
        public virtual string Synonyms { get; set; }
    }
}