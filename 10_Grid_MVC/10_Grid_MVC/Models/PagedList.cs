using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _10_Grid_MVC.Models
{
    public class PagedList<T>
    {
        public IEnumerable<T> Content { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalRecords / PageSize);
            }
        }
    }
}