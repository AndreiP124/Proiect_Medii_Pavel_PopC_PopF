using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proiect1.Models
{
    public class ReservationList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public int PeopleNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
