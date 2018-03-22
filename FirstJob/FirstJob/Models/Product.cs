using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SL;
using SQLite;

namespace FirstJob.Models
{
   public class Product : IBaseTable
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public String Name { get; set; }
        //public ObservableCollection<Color> Color { get; set; }
        //public ObservableCollection<Mesearement> Mesearement { get; set; }
    }
}
