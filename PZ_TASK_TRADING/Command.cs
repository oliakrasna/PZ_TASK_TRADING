using AutoMapper;
using DAL.Concrete;
using DTO;
using System;

namespace PZ_TASK_TRADING
{
    public class Command
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            AutoMapper.MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(GenreDAL).Assembly)
                );
            return config.CreateMapper();
        }

        public void ListAllBooks()
        {
            var dal = new BookDAL(Mapper);
            var books = dal.GetAllBooks();

            Console.WriteLine($"BookID\tBookName\t\tBookAuthor\t\t   GenreID   PublishingHouseID     Quantity    RowInsertTime            RowUpdateTime");

            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void ListAllGenres()
        {
            var dal = new GenreDAL(Mapper);
            var genres = dal.GetAllGenres();

            Console.WriteLine($"GenreID\t      GenreName\t                 RowInsertTime            RowUpdateTime");

            foreach (var genre in genres)
            {
                Console.WriteLine(genre.ToString());
            }
        }

        public void ListAllPublishingHouses()
        {
            var dal = new PublishingHouseDAL(Mapper);
            var publishing_houses = dal.GetAllPublishingHouses();

            Console.WriteLine($"PublishingHouseID\tPublishingHouseName\t  Addres                Number          RowInsertTime          RowUpdateTime");

            foreach (var publishing_house in publishing_houses)
            {
                Console.WriteLine(publishing_house.ToString());
            }
        }


        internal void CreateNewGenre(int genre_id, string genre_name )
        {
            var dal = new GenreDAL(Mapper);
            var genre = new GenreDTO
            {
                GenreID = genre_id,
                GenreName = genre_name,
            };
            genre = dal.CreateGenre(genre);
            Console.WriteLine($"New genre added!");
        }

        internal void CreateNewPublishingHouse(int publishing_house_id, string publishing_house_name, string adress, string number)
        {
            var dal = new PublishingHouseDAL(Mapper);
            var publishing_house = new PublishingHouseDTO
            {
                PublishingHouseID = publishing_house_id,
                PublishingHouseName = publishing_house_name,
                Adress = adress,
                Number = number,
                
            };
            publishing_house = dal.CreatePublishingHouse(publishing_house);
            Console.WriteLine($"New publishing house added!");
        }


        internal void CreateNewBook(int book_id, string book_name, string book_author, int genre_id, int publishing_house_id, int quantity)
        {
            var dal = new BookDAL(Mapper);
            var book = new BookDTO
            {
                BookID = book_id,
                BookName = book_name,
                BookAuthor = book_author,
                GenreID = genre_id,
                PublishingHouseID = publishing_house_id,
                Quantity = quantity,
                
            };
            book = dal.CreateBook(book);
            Console.WriteLine($"New book added!");
        }


        internal void RemoveGenre(int genre_id)
        {
            var dal = new GenreDAL(Mapper);
            Console.WriteLine($"Deleted user by ID = : {dal.RemoveGenreByID(genre_id).GenreID}");
        }


        internal void RemovePublishingHouse(int publishing_house_id)
        {
            var dal = new PublishingHouseDAL(Mapper);
            Console.WriteLine($"Deleted user by ID= : {dal.RemovePublishingHouseByID(publishing_house_id).PublishingHouseID}");
        }

        internal void RemoveBook(int book_id)
        {
            var dal = new BookDAL(Mapper);
            Console.WriteLine($"Deleted user by ID = : {dal.RemoveBookByID(book_id).BookID}");
        }

        internal void UpdateGenre(int genre_id, string genre_name)
        {
            var dal = new GenreDAL(Mapper);
            var genre = new GenreDTO
            {
                GenreID = genre_id,
                GenreName = genre_name
         
            };
            genre = dal.UpdateGenreByID(genre, genre_id);
            Console.WriteLine($"Update genre ID : {genre.GenreID}");
        }


        internal void UpdatePublishingHouse(int publishing_house_id, string publishing_house_name, string adress, string number)
        {
            var dal = new PublishingHouseDAL(Mapper);
            var publishing_house = new PublishingHouseDTO
            {
                PublishingHouseID = publishing_house_id,
                PublishingHouseName = publishing_house_name,
                Adress = adress,
                Number = number

            };
            publishing_house = dal.UpdatePublishingHouseByID(publishing_house, publishing_house_id);
            Console.WriteLine($"Update publishing house ID : {publishing_house.PublishingHouseID}");
        }


        internal void UpdateBook(int book_id, string book_name, string book_author, int genre_id, int publishing_house_id, int quantity)
        {
            var dal = new BookDAL(Mapper);
            var book = new BookDTO
            {
                BookID = book_id,
                BookName = book_name,
                BookAuthor = book_author,
                GenreID = genre_id,
                PublishingHouseID = publishing_house_id,
                Quantity = quantity

            };
            book = dal.UpdateBookByID(book, book_id);
            Console.WriteLine($"Update book ID : {book.BookID}");
        }



    }
}
