using System;
namespace DTO
{
    public class GenreDTO
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public override string ToString()
        {
            return $"{GenreID,-8}#\t{GenreName,-22}#\t{RowInsertTime,-22}#\t{RowUpdateTime}";
        }

    }
}
