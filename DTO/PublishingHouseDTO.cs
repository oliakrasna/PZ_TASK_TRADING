
using System;

namespace DTO
{
    public class PublishingHouseDTO
    {
        public int PublishingHouseID { get; set; }
        public string PublishingHouseName { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public override string ToString()
        {
            return $"{PublishingHouseID,-20}#\t{PublishingHouseName,-22}#\t{Adress,-22}#\t{Number,-14}#\t{RowInsertTime,-22}#\t{RowUpdateTime}";
        }

    }
}
