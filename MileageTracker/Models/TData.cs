using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MileageTracker.Models
{
    public class TData
    {
        public int ID { get; set; }
        public decimal unknown { get; set; }
        public decimal mbase { get; set; }
        public decimal result { get; set; }
    }

    public class TDataDBContext : DbContext
    {
        public DbSet<TData> TDataList { get; set; }
    }

}