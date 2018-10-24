using System;
using System.Collections.Generic;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class Category
    {
        public Category()
        {
            Story = new HashSet<Story>();
        }

        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Story> Story { get; set; }
    }
}
