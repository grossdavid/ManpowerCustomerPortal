using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapa.Intranet.Utilities
{
    public class PeriodNewsFilter : INewsFilter
    {
        public PeriodNewsFilter()
        {
        }

        public PeriodNewsFilter(DateTime periodFromDate, DateTime periodToDate)
        {
            PeriodFromDate = periodFromDate;
            PeriodToDate = periodToDate;
        }

        public DateTime PeriodFromDate { get; protected internal set; }
        public DateTime PeriodToDate { get; protected internal set; }

        public string Text
        {
            get
            {
                return (PeriodFromDate.Year == DateTime.Now.Year) ? PeriodFromDate.ToString("MMMM yyyy") : PeriodFromDate.ToString("yyyy");
            }
        }

        public string Value
        {
            get
            {
                return "p:" + PeriodFromDate.ToString("yyyyMM") + "-" + PeriodToDate.ToString("yyyyMM");
            }
        }

        public bool Selected { get; set; }
    }
}
