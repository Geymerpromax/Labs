/*
Необходимо разработать систему учета книг для библиотеки. 
Публичный доступ к данным всех классов должен осуществляться с помощью свойств или автоматических свойств.
*/

using System;
using System.Collections.Generic;
using System.Linq;


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
        public static List<StoredBookUsage> StoredBooksUsage { get; set; } = new List<StoredBookUsage>();

        public bool IsAvailableBook(StoredBook storedBook)
        {
            return storedBook.isAvailable;
        }

        public void ShowAllBooks()
        {
            foreach (Book book in Books)
            {
                int availableCount = StoredBooks.Count(sb => sb.book == book && sb.isAvailable);
                Console.WriteLine($"Книга: {book.title}\nКоличество доступных экземпляров: {availableCount}");
                book.ShowAll();
            }
        }

        public bool AnyAvailableBooks()
        {
            return StoredBooks.Any(book => book.isAvailable);
        }

        public void GiveTheStorageBook(StoredBook storedBook, User user)
        {
            if (!storedBook.isAvailable)
            {
                Console.WriteLine("Нет доступных экземпляров книги для выдачи.");
                return;
            }

            StoredBookUsage storedBookUsage = new StoredBookUsage();
            storedBookUsage.bookInstance = storedBook;
            storedBookUsage.user = user;
            storedBook.isAvailable = false;
            StoredBooksUsage.Add(storedBookUsage);
            Console.WriteLine("Книга выдана, запись сделана");
        }

        public void AcceptBookBack(StoredBookUsage storedBookUsage)
        {
            storedBookUsage.bookInstance.isAvailable = true;
            storedBookUsage.returnDate = DateTime.Now;
            Console.WriteLine("Книга принята обратно, запись обновлена");
        }

        public void ShowBookIssueJournal()
        {
            Console.WriteLine("Журнал выдачи книг:");
            foreach (StoredBookUsage usage in StoredBooksUsage)
            {
                Console.WriteLine($"ID: {usage.id}, Книга: {usage.bookInstance.book.title}, " +
                                  $"Пользователь: {usage.user.surname} {usage.user.name}, " +
                                  $"Дата выдачи: {usage.issueDate}, Дата возврата: {(usage.returnDate.HasValue ? usage.returnDate.Value.ToString() : "еще не возвращена")}");
            }
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
            Author authorSex = new Author("Колбышев", "Александр", "Иванович");

            List<Author> bookOneAuthors = new List<Author> { authorOne, authorSex };

            Book bookOne = new Book("Тени прошлого", bookOneAuthors, "2008");
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

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Взять книгу");
                Console.WriteLine("2. Вернуть книгу");
                Console.WriteLine("3. Показать список всех экземпляров книг");
                Console.WriteLine("4. Показать журнал выдачи книг");
                Console.WriteLine("5. Выход\n");

                Console.Write("Введите номер действия: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (!applicationContext.AnyAvailableBooks())
                        {
                            Console.WriteLine("Нет доступных книг для выдачи.\n");
                            break;
                        }

                        Console.Write("Введите инвентарный номер книги: ");
                        int inventoryNumber;
                        if (int.TryParse(Console.ReadLine(), out inventoryNumber))
                        {
                            StoredBook selectedBook = ApplicationContext.StoredBooks.Find(book => book.inventoryNumber == inventoryNumber);
                            if (selectedBook != null)
                            {
                                applicationContext.GiveTheStorageBook(selectedBook, ruslan);
                            }
                            else
                            {
                                Console.WriteLine("Книга с таким инвентарным номером не найдена.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат инвентарного номера.\n");
                        }
                        break;
                    case "2":
                        if (!ApplicationContext.StoredBooksUsage.Any(usage => usage.user == ruslan && usage.returnDate == null))
                        {
                            Console.WriteLine("У вас нет книг для возврата.");
                            break;
                        }
                        Console.Write("Введите ID записи выдачи книги для возврата: ");
                        int usageID;
                        if (int.TryParse(Console.ReadLine(), out usageID))
                        {
                            StoredBookUsage selectedUsage = ApplicationContext.StoredBooksUsage.Find(usage => usage.id == usageID);
                            if (selectedUsage != null)
                            {
                                applicationContext.AcceptBookBack(selectedUsage);
                            }
                            else
                            {
                                Console.WriteLine("Запись с таким ID не найдена.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID.\n");
                        }
                        break;
                    case "3":
                        applicationContext.ShowAllBooks();
                        break;
                    case "4":
                        applicationContext.ShowBookIssueJournal();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите одно из действий из меню.\n");
                        break;
                }
            }
        }
    }

}
