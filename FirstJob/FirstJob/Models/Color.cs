using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SL;
using SQLite;

namespace FirstJob.Models
{
    public class Color : IBaseTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Colorcode { get; set; }
        public string Colorname { get; set; }
       // public Product Product { get; set; }

    }
}
