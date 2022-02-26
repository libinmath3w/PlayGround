using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// to store the data of Turf
    /// </summary>
    public  class TurfModel
    {
        public int TurfID { get; set; }
        public string  TurfName { get; set; }
        public string  TurfLocation { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public  int TurfCategoryID { get; set; }
        public float TurfPrice { get; set; }
        public string TurfCity { get; set; }
        public string TurfState { get; set; }
        public string   Zip { get; set; }
        public string TurfImage { get; set; }
    }
}
