using System;
namespace DTO
{
    public class BookDTO
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int GenreID { get; set; }
        public int PublishingHouseID { get; set; }
        public int Quantity { get; set; }
        public DateTime  RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public override string ToString()
        {
            return $"{BookID,-6}#\t{BookName,-22}#\t{BookAuthor,-25}#\t{GenreID,-3}#\t{PublishingHouseID,-17}#\t{Quantity,-4}#\t{RowInsertTime, -22}#\t{RowUpdateTime}";
        }





    }
}
