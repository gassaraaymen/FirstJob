using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SL;
using SQLite;

namespace FirstJob.Models
{
    public class Mesearement : IBaseTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
       // public Product Product { get; set; }
    }
}
