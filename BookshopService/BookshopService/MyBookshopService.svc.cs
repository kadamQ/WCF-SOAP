using BookshopDatabase;
using BookshopDatabase.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookshopService
{
    public class MyBookshopService : IMyBookshopService
    {
        public static List<User> loggedIn = new List<User>();

        #region Login
        public User Login(string username, string password)
        {
            try
            {
                if (username == "admin" && password == "admin")
                {
                    User user = new User(username, Guid.NewGuid().ToString());
                    lock (loggedIn)
                    {
                        loggedIn.Add(user);
                    }
                    return user;
                }
                else
                {
                    throw new Exception("Unsuccessful login!");
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<UnsuccessfullLoginFault>(new UnsuccessfullLoginFault(ex.Message));
            }
        }
        #endregion

        #region Logout
        public bool Logout(User user)
        {
            try
            {
                if (HasGuid(user))
                {
                    lock (loggedIn)
                    {
                        var item = loggedIn.Where(u => u.Username == user.Username && u.GUID == user.GUID).First();
                        loggedIn.Remove(item);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion

        #region HasGuid
        public bool HasGuid(User user)
        {
            try
            {
                foreach (var item in loggedIn)
                {
                    if (item.GUID == user.GUID && item.Username == user.Username)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion

        #region Delete
        public bool Delete(User user, string isbn)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                booksTable.Delete(booksTable.ListByISBN(isbn));
            }
            return false;
        }
        #endregion

        #region DiscountAll
        public bool DiscountAll(User user, int pricePercentage)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                return booksTable.DiscountAll(pricePercentage) == 1;
            }
            return false;
        }
        #endregion

        #region DiscountByAuthor
        public bool DiscountByAuthor(User user, string author, int pricePercentage)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                return booksTable.DiscountByAuthor(author, pricePercentage) == 1;
            }
            return false;
        }
        #endregion

        #region DiscountOne
        public bool DiscountOne(User user, string isbn, int pricePercentage)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                return booksTable.DiscountOne(isbn, pricePercentage) == 1;
            }
            return false;
        }
        #endregion

        #region Insert
        public bool Insert(User user, string isbn, string title, string author, string publicationDate, int price, int instock)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                BookModel book = new BookModel();
                book.Isbn = isbn;
                book.Title = title;
                book.Author = author;
                book.PublicationDate = publicationDate;
                book.Price = price;
                book.Instock = instock;
                return booksTable.Insert(book) == 1;
            }
            return false;
        }
        #endregion

        #region ListAll
        public List<BookModel> ListAll(User user)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                return booksTable.Select();
            }
            return null;
        }
        #endregion

        #region ListByIsbn
        public BookModel ListByIsbn(User user, string isbn)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                return booksTable.ListByISBN(isbn);
            }
            return null;
        }
        #endregion

        #region Update
        public bool Update(User user, BookModel bookModel, int price, int instock)
        {
            if (HasGuid(user))
            {
                BooksTable booksTable = new BooksTable();
                return booksTable.Update(bookModel, price, instock) == 1;
            }
            return false;
        }
        #endregion
    }
}
