using System.Collections.Generic;

namespace Core.Entity
{
    public class FilteringList<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}