using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenreDAL
    {
        List<GenreDTO> GetAllGenres();
        GenreDTO CreateGenre(GenreDTO genre);
    }

}
