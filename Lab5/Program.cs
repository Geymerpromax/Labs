/*
Необходимо разработать систему учета книг для библиотеки. 
Публичный доступ к данным всех классов должен осуществляться с помощью свойств или автоматических свойств.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Lab5
{
/*
1. Разработать открытый класс User, описывающий пользователя библиотеки. 
Класс содержит следующие данные: идентификатор, фамилия, имя, отчество, контактный телефон. 
Идентификатор должен быть открыт для чтения, но закрыт для записи. Остальные данные – открыты для чтения и записи. 
Создать конструктор с одним параметром – идентификатором.
*/
    public class User
    {
        public static int globalID { get; set; } = 0;
        public int id { get; set; } = 0;
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string phoneNumber { get; set; }
        
        public User(string newSurname, string newName, string newPatronymic, string newPhoneNumber)
        {
            id++;
            surname = newSurname;
            name = newName;
            patronymic = newPatronymic;
            phoneNumber = newPhoneNumber;
        }

    }

  

    /*
    2. Разработать открытый класс Author, описывающий автора книги. 
    Класс содержит следующие данные: идентификатор, фамилия, имя, отчество. 
    Идентификатор должен быть открыт для чтения, но закрыт для записи. Остальные данные – открыты для чтения и записи. 
    Создать конструктор с одним параметром – идентификатором.
    */
    public class Author
    {
        public static int globalID { get; set; } = 0;
        public int id { get; set; } = 0;
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }

        public Author(string newSurname, string newName, string newPatronymic)
        {
            id++;
            surname = newSurname;
            name = newName;
            patronymic = newPatronymic;
        }
        public void ShowAll()
        {
            Console.WriteLine(surname + " " + name + " " + patronymic);
        }
    }
/*
3. Разработать открытый класс Book, описывающий одну книгу. 
Класс содержит следующие данные: ид, название, авторы (список объектов класса Author), год издания, экземпляры (список объектов класса StoredBook). 
Идентификатор должен быть открыт для чтения, но закрыт для записи. Остальные данные – открыты для чтения и записи. 
Создать конструктор с одним параметром – идентификатором.
*/
    public class Book
    {
        public static int globalID { get; set; } = 0;
        public int id { get; set; } = 0;
        public string title { get; set; }
        public List<Author> authors { get; set; } = new List<Author>();
        public string publicationYear { get; set; }

        public Book(string newTitle, Author newAuthors, string newPublicationYear)
        {
            id = globalID++;
            title = newTitle;
            authors.Add(newAuthors);
            publicationYear = newPublicationYear;
        }
        public Book(string newTitle, List<Author> newAuthors, string newPublicationYear)
        {
            id = globalID++;
            title = newTitle;
            authors = newAuthors;
            publicationYear = newPublicationYear;
        }
        public void ShowAll()
        {
            Console.WriteLine("ID " + id);
            Console.WriteLine("Название: " + title);
            Console.WriteLine("Авторы: ");
            foreach (Author author in authors)
            {
                author.ShowAll();
            }
            Console.WriteLine("Год Издания: " + publicationYear);
            Console.WriteLine();
        }
    }
    /*
    4. Разработать открытый класс StoredBook, описывающий хранимый экземпляр книги. 
    Класс содержит следующие данные: идентификатор, инвентарный номер, книга , номер стеллажа, номер полки в стеллаже, номер книги на полке, признак наличия книги IsAvailable (в библиотеке книга или выдана на руки). 
    Идентификатор должен быть открыт для чтения, но закрыт для записи. Остальные данные – открыты для чтения и записи. 
    Создать конструктор с одним параметром – идентификатором.
    */
    public class StoredBook 
    {
        public static int globalID { get; set; } = 0;
        public int id { get; set; } = 0;
        public int inventoryNumber { get; set; }
        public Book book { get; set; }
        public int shelfNumber { get; set; }
        public int shelfPosition { get; set; }
        public int bookNumberOnShelf { get; set; }
        public bool isAvailable { get; set; }

        public StoredBook(int newInventoryNumber, Book newBook, int newSelfNumber, int newBookNumberOnShelf, bool newIsAvailable)
        {
            inventoryNumber = newInventoryNumber; 
            book = newBook; 
            shelfNumber = newSelfNumber;
            bookNumberOnShelf = newBookNumberOnShelf;
            isAvailable = newIsAvailable;
            id = globalID++;
        }
    }

    public class StoredBookUsage
    {
        public static int globalID { get; set; } = 0;
        public int id { get; set; } = 0;
        public StoredBook bookInstance { get; set; }
        public User user { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime? returnDate { get; set; }

        public StoredBookUsage()
        {
            id = globalID++;
        }

        
    }

    public class ApplicationContext
    {
        public static List<Book> Books { get; set; } = new List<Book>();
        public static List<StoredBook> StoredBooks { get; set; } = new List<StoredBook>();
        public static List<StoredBookUsage> StoredBooksUsage { get; set;} = new List<StoredBookUsage>();

        public bool IsAvailableBook(StoredBook storedBook)
        {
            return storedBook.isAvailable;
        }
        public void ShowAllBook()
        {
            foreach (Book book in Books)
            {
                book.ShowAll();
            }
        }
        public void GiveTheStorageBook(StoredBook storedBook, User user)
        {
            StoredBookUsage storedBookUsage = new StoredBookUsage();
            storedBookUsage.bookInstance = storedBook;
            storedBookUsage.user = user;
            storedBook.isAvailable = false;
            StoredBooksUsage.Add(storedBookUsage);
            Console.WriteLine("Книга выдана, запись сделана");
        }
    }

    class Program
    {
        static void Main()
        {
            User ruslan = new User("Дергунов", "Руслан", "Альбертович", "2003");

            Author authorOne = new Author("Иванова", "Александра", "Игоревна");              
            Author authorTwo = new Author("Соколов", "Михаил", "Юрьевич");
            Author authorThree = new Author("Петрова", "Екатерина", "Олеговна");
            Author authorFour = new Author("Михайлов", "Дмитрий", "Иванович");
            Author authorSex = new Author("Колбышев", "Александр ", "Иванович");

            List<Author> bookOneAutors = new List<Author> { authorOne, authorSex };

            Book bookOne = new Book("Тени прошлого", bookOneAutors, "2008");
            Book bookTwo = new Book("Звездный лабиринт", authorTwo, "2015");
            Book bookThree = new Book("Поток снов", authorThree, "2012");
            Book bookFour = new Book("Сиреневые холмы", authorFour, "2019");
            Book bookFive = new Book("Перекрестие времени", authorSex, "2006");

            ApplicationContext.Books = new List<Book> { bookOne, bookTwo, bookThree, bookFour, bookFive };


            StoredBook firstStoredBookOne = new StoredBook(1, bookOne, 45, 56, true);
            StoredBook secondStoredBookOne = new StoredBook(2, bookOne, 45, 57, false);

            StoredBook firstStoredbookTwo = new StoredBook(3, bookTwo, 35, 51, true);
            StoredBook firstStoredbookThree = new StoredBook(4, bookThree, 4, 8, true);
            StoredBook firstStoredbookFour = new StoredBook(5, bookFour, 12, 23, true);
            StoredBook firstStoredbookFive = new StoredBook(6, bookFive, 78, 54, true);

            ApplicationContext.StoredBooks = new List<StoredBook> { firstStoredBookOne, secondStoredBookOne, firstStoredbookTwo, firstStoredbookThree, firstStoredbookFour, firstStoredbookFive };

            StoredBookUsage storedBookUsage = new StoredBookUsage();

            ApplicationContext applicationContext = new ApplicationContext();


            /*
            6.	Реализовать открытые методы:
            •	Выдать книгу пользователю
            •	Принять книгу обратно
            •	Показать список всех экземпляров книг
            •	Показать журнал выдачи книг
            */



            while(true)
            {
                Console.WriteLine("Добро пожаловать в электроную библиотеку: 'Фича - не баг'");
                Console.WriteLine("Главное меню");
                Console.WriteLine("1. Взять книгу");
                Console.WriteLine("2. Вернуть книгу");
                Console.WriteLine("3. Показать список всех экземпляров книг");
                Console.WriteLine("4. exit");
                Console.WriteLine("5. Показать журнал выдачи книг");

                switch (Console.ReadLine())
                {
                    case "1":
                        //storedBookUsage.ShowAllBook();
                        Console.WriteLine("Доступные экземпляры книг: ");
                        foreach (StoredBook sb in ApplicationContext.StoredBooks)
                        {
                            if (applicationContext.IsAvailableBook(sb))
                            {
                                Console.WriteLine(sb.id + ". " + sb.book.title);
                            }
                        }
                        Console.WriteLine("Выберите желаемую книгу: ");
                        

                        while(true)
                        {
                            int ide = Convert.ToInt32(Console.ReadLine());
                            foreach (StoredBook sb in ApplicationContext.StoredBooks)
                            {
                                if (ide == sb.id)
                                {
                                    if (applicationContext.IsAvailableBook(sb))
                                    {
                                        applicationContext.GiveTheStorageBook(sb, ruslan);
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка выбора! Попробуйте ещё раз");
                                    }

                                }
                            }
                            break;
                        }
                        

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":
                        Console.Clear();
                        break;
                }

            }  
            



        }
    }

}
