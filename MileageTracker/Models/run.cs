using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MileageTracker.Models
{
    public class Run
    {
        public int ID { set; get; }
        public decimal Mileage { set; get; }

        [Display(Name = "Date of Run")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RunDate { set; get; }
    }

    public class RunDBContext : DbContext
    {
        public DbSet<Run> Runs { get; set; }
    }
}