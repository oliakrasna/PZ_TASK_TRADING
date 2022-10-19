using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class GenreDAL : IGenreDAL
    {
        private readonly IMapper _mapper;

        public GenreDAL(IMapper mapper)
        {
            _mapper = mapper;

        }
        public GenreDTO CreateGenre(GenreDTO genre)
        {
            using (var entities = new TradingEntities())
            {
                var genreInDB = _mapper.Map<Genre>(genre);
                genreInDB.RowInsertTime = System.DateTime.Now;
                genreInDB.RowUpdateTime = System.DateTime.Now;
                entities.Genres.Add(genreInDB);
                entities.SaveChanges();
                return _mapper.Map<GenreDTO>(genreInDB);
            }
        }

        public List<GenreDTO> GetAllGenres()
        {
            using (var entities = new TradingEntities())
            {
                var genres = entities.Genres.ToList();
                return _mapper.Map<List<GenreDTO>>(genres);
            }

        }

        public GenreDTO RemoveGenreByID(int id)
        {
            using (var entites = new TradingEntities())
            {
                var genreInDB = entites.Genres.SingleOrDefault(x => x.GenreID == id);
                if (genreInDB != null)
                {
                    entites.Genres.Remove(genreInDB);
                    entites.SaveChanges();
                }
                return _mapper.Map<GenreDTO>(genreInDB);
            }

        }

        public GenreDTO UpdateGenreByID(GenreDTO genre, int id)
        {
            using (var entites = new TradingEntities())
            {
                var genreInDB = _mapper.Map<Genre>(genre);
                genreInDB = entites.Genres.SingleOrDefault(x => x.GenreID == id);
                if (genreInDB != null)
                {
                    genreInDB.RowUpdateTime = DateTime.Now;
                    genreInDB.GenreID = genre.GenreID;
                    genreInDB.GenreName = genre.GenreName;
                 
                    entites.SaveChanges();
                }
                return _mapper.Map<GenreDTO>(genreInDB);
            }
        }








    }

}
