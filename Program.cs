using System;

namespace Wk7Ex1
{
    internal class Book
    {
        //Variable to store the book title.
        private string title;
        //variable to store the book author.
        private string author;
        //Variable to store the book genre.
        private string genre;
        //Variable to store the book price.
        private double price;
        //Construtor to create a book object.
        public Book(string title, string author, string genre, double price)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.price = price;
        }
        //Variable accessor for Title.
        public string Title
        {
            get { return title; }
        }
        //Variable accessor for Author.
        public string Author
        {
            get { return author; }
        }
        //Variable accessor for Genre.
        public string Genre
        {
            get { return genre; }
        }
        //Variable accessor for Price.
        public double Price
        {
            get { return price; }
            set
            {
                //Condition to check is price is negative.
                if (price < 0)
                {
                    Console.WriteLine("Price cannot be negative");
                }
                else
                {
                    price = value;
                }
            }
        }
    }
    class Program
    {
        //Main Method.
        static void Main(string[] args)
        {
            //Book List.
            List<Book> books = new List<Book>();
            books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 15.99));
            books.Add(new Book("1984", "George Orwell", "Dystopian", 12.99));
            books.Add(new Book("Pride and Prejudice", "Jane Austen", "Romance", 9.99));
            books.Add(new Book("Moby Dick", "Herman Melville", "Adventure", 18.99));
            books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 10.99));
            books.Add(new Book("Brave New Word", "Aldous Huxley", "Dystopian", 14.99));
            books.Add(new Book("War and Peace", "Leo Tolstoy", "Historical Fiction", 25.99));
            //Int variable for the menu option.
            int menuOption = 0;
            //Variable to number the queries outputs.
            int index = 1;
            //Loop to continue asking the user for the menu input.
            do
            {
                //Styling.
                Console.WriteLine("-------------------------------------");
                //Styling.
                Console.WriteLine("LINQ Menu:");
                //Styling.
                Console.WriteLine("-------------------------------------");
                //Option Menu.
                Console.WriteLine("1. Display Book List\n2. Select books that cost more than $12\n3. Order books by price (ascending)\n4. Group books by genre\n5. Select only the titles and authors of books (projected data)\n6. Exit");
                //Styling.
                Console.WriteLine("-------------------------------------");
                //Styling.
                Console.Write("PLEASE SELECT A LINQ QUERY OPTION: ");
                //Stores user input for the option menu.
                menuOption = Convert.ToInt32(Console.ReadLine());
                //Switch for the menu options.
                switch (menuOption)
                {
                    case 1:
                        //Resets the variable to number the queries outputs.
                        index = 1;
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Styling.
                        Console.WriteLine("BOOK LIST");
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //foreach loop to dispay the book list.
                        foreach (var book in books)
                        {
                            //Prints the book list
                            Console.WriteLine($"({index}) - {book.Title}, {book.Author}, {book.Genre}, {book.Price}");
                            //Increments the index variable.
                            index++;
                        }
                        //Exits the case.
                        break;
                    case 2:
                        //LINQ Query to select books that cost more than $12.
                        var moreThan12Bucks = books.Where(b => b.Price > 12).ToList();
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Styling.
                        Console.WriteLine("THESE BOOKS COST MORE THAN $12");
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Foreach loop to display the books that cost more than $12.
                        foreach (var book in moreThan12Bucks)
                        {
                            //Prints the book title and price.
                            Console.WriteLine($"* {book.Title} - ({book.Price})");
                        }
                        //Exits the case.
                        break;
                    case 3:
                        //Variable to store the LINQ Query to order books by price (ascending).
                        var orderByPrice = books.OrderBy(t => t.Price).ToList();
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Styling.
                        Console.WriteLine("BOOKS ORDERED BY PRICE (ASCENDING)");
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Resets the index variable.
                        index = 0;
                        //Foreach loop to display the books ordered by price.
                        foreach (var book in orderByPrice)
                        {
                            //Increments the index variable.
                            index++;
                            //Displays the book title and price.
                            Console.WriteLine($"({index}) {book.Title}, {book.Price}");
                        }
                        //Exits the case.
                        break;
                    case 4:
                        //Variable to store the LINQ Query to group books by genre.
                        var orderByGenre = books.GroupBy(b => b.Genre);
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Styling.
                        Console.WriteLine("BOOKS GROUPED BY GENRE");
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Foreach loop to display the books grouped by genre.
                        foreach (var group in orderByGenre)
                        {
                            //Prints the genre.
                            Console.WriteLine($"Genre: {group.Key}");
                            //Foreach loop to display the books for each genre.
                            foreach (var book in group)
                            {
                                //Prints the book title inside the genre category.
                                Console.WriteLine($" * {book.Title}");
                            }
                        }
                        //Exits the case.
                        break;
                    case 5:
                        //Variable to store the LINQ Query to select only the titles and authors of books (projected data).
                        var projectedBooks = books.Select(b => new { b.Title, b.Author, }).ToList();
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Styling.
                        Console.WriteLine("TITLES AND AUTHORS");
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Loop to display the titles and authors of the books.
                        foreach (var book in projectedBooks)
                        {
                            //Prints the book title and author.
                            Console.WriteLine($"* {book.Title} by {book.Author}.");
                        }
                        //Exits the case.
                        break;
                    case 6:
                        //Exits the menu.
                        break;
                    default:
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        //Styling.
                        Console.WriteLine("Enter a number between 1 and 6.");
                        //Styling.
                        Console.WriteLine("-------------------------------------");
                        break;
                }
                //Repeat until the user enters 6.
            } while (menuOption != 6);

            //Styling.
            Console.WriteLine();
            //Signal the end of the program to the user.
            Console.WriteLine("End of the program, Press Any Key to Exit...");
            //Read the key input and exit
            Console.ReadLine();

            //Pushed to GitHub Repo Wk7Ex1

        }
    }
}