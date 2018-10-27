using System;
using System.Collections.Generic;
using Kigg.DomainObjects;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class KnownSource
    {
        public string Url { get; set; }
        public KnownSourceGrade Grade { get; set; }
    }
}
