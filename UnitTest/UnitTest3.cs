using AutoMapper;
using DAL.Concrete;
using DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest3
    {

        private IMapper _mapper;
        [OneTimeSetUp]
        public void SetupOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(GenreDAL).Assembly)
                );
            _mapper = config.CreateMapper();
        }

        [Test]
        public void CreateGenreTest()
        {
            GenreDAL dal = new GenreDAL(_mapper);
            var result = dal.CreateGenre(new GenreDTO
            {
                GenreID = 13,
                GenreName = "test_genre_name"

            });
            Assert.IsTrue(result.GenreID != 0);
        }


        [Test]
        public void GetAllGenresTest()
        {
            GenreDAL dal = new GenreDAL(_mapper);

            var genres = dal.GetAllGenres();
            Assert.IsTrue(genres.Count > 0);
        }

        [Test]
        public void UpdateGenreByIDTest()
        {
            GenreDTO newGenre = new GenreDTO
            {
                GenreName = "test_genre_name_2"
            };
            string _testGenre = " ";

            var dal = new GenreDAL(_mapper);

            var genresList = dal.GetAllGenres();
            int id = genresList.SingleOrDefault(x => x.GenreName == _testGenre).GenreID;

            Assert.IsTrue(dal.UpdateGenreByID(newGenre, id).GenreName == newGenre.GenreName);
        }


        [Test]
        public void RemoveGenreTest()
        {
            GenreDAL dal = new GenreDAL(_mapper);
            var genre = dal.CreateGenre(new GenreDTO
            {
                GenreID = 14,
                GenreName = "test_genre_name_4"
            });
            dal.RemoveGenreByID(genre.GenreID);
            var deleted = dal.GetAllGenres().Find(x => x.GenreName == genre.GenreName);

            Assert.IsNull(deleted);
        }

    }
}