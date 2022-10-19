using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_TASK_TRADING
{
    public class Menu
    {

        private Command command = new Command();
        public void ShowMenu()
        {
            string userInput = "";
            do
            {
                ShowMainMenu();
                userInput = Console.ReadLine();
            }
            while (userInput != "e");
        }

        void ShowMainMenu()
        {
            string menu = @"Welcometo the book company!
                            Select the section you want to work with :
                            b - Books;
                            p - Publishing houses;
                            g - Genres;
                            e - Exit";
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            MainMenuInput(userInput);

        }

        private void MainMenuInput(char userInput)
        {
            switch (userInput)
            {
                case 'b':
                    ShowBooksMenu();
                    break;
                case 'p':
                    ShowPublishingHousesMenu();
                    break;
                case 'g':
                    ShowGenresMenu();
                    break;
                case 'e':
                    break;
                default:
                    Console.WriteLine("The wrong command was selected!");
                    break;
            }

        }

        private void ShowBooksMenu()
        {
            string menu = @"Select the section you want to work with :
                            1 - For adding new book;
                            2 - For deleting the book;
                            3 - For updating book in list;
                            4 - For showing list of books;
                            b - Comeback to main menu;
                            q - Exit";
            Console.Clear();
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            BooksMenuInput(userInput);
        }


        private void BooksMenuInput(char userInput)
        {
            switch (userInput)
            {
                case '1':
                    ForAddingBook();
                    BackBooksMenu();
                    break;
                case '2':
                    command.RemoveBook(GetID());
                    BackBooksMenu();
                    break;
                case '3':
                    ForUpdateBook();
                    BackBooksMenu();
                    break;
                case '4':
                    command.ListAllBooks();
                    BackBooksMenu();
                    break;
                case 'b':
                    Console.Clear();
                    ShowMainMenu();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("The wrong command was selected!");
                    break;
            }
        }

        private void ShowPublishingHousesMenu()
        {
            string menu = @"Select the section you want to work with :
                            1 - For adding new publishing house;
                            2 - For deleting the publishing house;
                            3 - For updating publishing house in list;
                            4 - For showing list of publishing houses;
                            b - Back to main menu;
                            q - Exit";
            Console.Clear();
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            PublishingHousesMenuInput(userInput);
        }



        private void PublishingHousesMenuInput(char userInput)
        {
            switch (userInput)
            {
                case '1':
                    ForAddingPublishingHouse();
                    BackPublishingHousesMenu();
                    break;
                case '2':
                    command.RemovePublishingHouse(GetID());
                    BackPublishingHousesMenu();
                    break;
                case '3':
                    ForUpdatePublishingHouse();
                    BackPublishingHousesMenu();
                    break;
                case '4':
                    command.ListAllPublishingHouses();
                    BackPublishingHousesMenu();
                    break;
                case 'b':
                    Console.Clear();
                    ShowMainMenu();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("The wrong command was selected!");
                    break;
            }
        }


        private void ShowGenresMenu()
        {
            string menu = @"Select the section you want to work with :
                            1 - For adding new genre;
                            2 - For deleting the genre;
                            3 - For updating genre in list;
                            4 - For showing list of genress;
                            b - Comeback to main menu;
                            q - Exit";
            Console.Clear();
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            GenresMenuInput(userInput);
        }


        private void GenresMenuInput(char userInput)
        {
            switch (userInput)
            {
                case '1':
                    ForAddingGenre();
                    BackGenresMenu();
                    break;
                case '2':
                    command.RemoveGenre(GetID());
                    BackGenresMenu();
                    break;
                case '3':
                    ForUpdateGenre();
                    BackGenresMenu();
                    break;
                case '4':
                    command.ListAllGenres();
                    BackGenresMenu();
                    break;
                case 'b':
                    Console.Clear();
                    ShowMainMenu();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("The wrong command was selected!");
                    break;
            }
        }


        private int GetID()
        {
            Console.WriteLine("Type th ID you chose: ");
            return Convert.ToInt32(Console.ReadLine());
        }


        private void ForAddingBook()
        {
            Console.Clear();
            Console.WriteLine("Type the book ID : ");
            int BookID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type name of book : ");
            string BookName = Console.ReadLine();
            Console.WriteLine("Type book author : ");
            string BookAuthor = Console.ReadLine();
            Console.WriteLine("Type the genre ID : ");
            int GenreID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type the publishing house ID : ");
            int PublishingHouseID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type the quantity : ");
            int Quantity = Convert.ToInt32(Console.ReadLine());


            command.CreateNewBook(BookID, BookName, BookAuthor, GenreID, PublishingHouseID, Quantity);
        }


        private void ForAddingPublishingHouse()
        {
            Console.Clear();
            Console.WriteLine("Type the publishing house ID : ");
            int PublishingHouseID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type publishing house name: ");
            string PublishingHouseName = Console.ReadLine();
            Console.WriteLine("Type the adress of publishing house : ");
            string Adress = Console.ReadLine();
            Console.WriteLine("Type the number of publishing house : ");
            string Number = Console.ReadLine();


            command.CreateNewPublishingHouse(PublishingHouseID, PublishingHouseName, Adress, Number);
        }


        private void ForAddingGenre()
        {
            Console.Clear();
            Console.WriteLine("Type the genre ID : ");
            int GenreID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type genre name: ");
            string GenreName = Console.ReadLine();
            

            command.CreateNewGenre(GenreID, GenreName);
        }



        private void ForUpdateBook()
        {
            Console.Clear();
            int id = GetID();
            Console.WriteLine("Type the book ID : ");
            int BookID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type name of book : ");
            string BookName = Console.ReadLine();
            Console.WriteLine("Type book author : ");
            string BookAuthor = Console.ReadLine();
            Console.WriteLine("Type the genre ID : ");
            int GenreID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type the publishing house ID : ");
            int PublishingHouseID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type the quantity : ");
            int Quantity = Convert.ToInt32(Console.ReadLine());

            command.UpdateBook(BookID, BookName, BookAuthor, GenreID, PublishingHouseID, Quantity);
        }



        private void ForUpdatePublishingHouse()
        {
            Console.Clear();
            Console.WriteLine("Type the publishing house ID : ");
            int PublishingHouseID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type publishing house name: ");
            string PublishingHouseName = Console.ReadLine();
            Console.WriteLine("Type the adress of publishing house : ");
            string Adress = Console.ReadLine();
            Console.WriteLine("Type the number of publishing house : ");
            string Number = Console.ReadLine();

            command.UpdatePublishingHouse(PublishingHouseID, PublishingHouseName, Adress, Number);
        }


        private void ForUpdateGenre()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Type the genre ID : ");
            int GenreID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type genre name: ");
            string GenreName = Console.ReadLine();

            command.UpdateGenre(GenreID, GenreName);
        }


        private void BackBooksMenu()
        {
            Console.Write("Type b to comeback to preceding menu: ");
            char user_input = Console.ReadLine()[0];
            if (user_input == 'b') { ShowBooksMenu(); }
            else { Console.WriteLine("The wrong command was selected!"); }
        }

        private void BackPublishingHousesMenu()
        {
            Console.Write("Type b to comeback to preceding menu: ");
            char user_input = Console.ReadLine()[0];
            if (user_input == 'b') { ShowPublishingHousesMenu(); }
            else { Console.WriteLine("The wrong command was selected!"); }
        }


        private void BackGenresMenu()
        {
            Console.Write("Type b to comeback to preceding menu: ");
            char user_input = Console.ReadLine()[0];
            if (user_input == 'b') { ShowGenresMenu(); }
            else { Console.WriteLine("The wrong command was selected!"); }
        }













    }



}
