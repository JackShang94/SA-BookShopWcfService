using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopWcfService
{
    public class BusinessLogic
    {
       static  BookshopEntities context = new BookshopEntities();
        public static int UpdateBook(int BookID, string Title, int CategoryID, string ISBN, string Author, int Stock, decimal Price)
        {
            Book book = context.Books.Where(x => x.BookID == BookID).First();
            book.Title = Title;
            book.CategoryID = CategoryID;
            book.ISBN = ISBN;
            book.Author = Author;
            book.Stock = Stock;
            book.Price = Price;
            return context.SaveChanges();
        }
        public static int GetCategoryID(string category)
        {
            Category c = context.Categories.Where(x => x.Name == category).FirstOrDefault();
            if (c == null) { return 0; }
            else
                return c.CategoryID;
        }
        public static List<Book> SearchAllBooks()
        {
            return context.Books.ToList<Book>();
        }
        public static List<Book> SearchBookByTitle(string Title)
        {
            return context.Books.Where(x => x.Title.ToLower().Contains(Title.ToLower().Trim())).ToList<Book>();
        }
        public static Book SearchBookByBookId(int bookID)
        {
            Book searchedID = context.Books.Where(x => x.BookID == bookID).FirstOrDefault();
            return searchedID;
        }
        public static List<Book> SearchBookByCategory(string category)
        {
            int categoryID = GetCategoryID(category);
            return context.Books.Where(x => x.CategoryID == categoryID).ToList<Book>();
        }
        public static String GetBookTitle(int bookID)
        {         
            return context.Books.Where(x => x.BookID == bookID).FirstOrDefault().Title;
        }
        public static List<Category> FindAllCategories()
        {
            return context.Categories.ToList<Category>();
        }
        public static List<Book> SearchBookByAuthor(string Author)
        {
            return context.Books.Where(x => x.Author.ToLower().Contains(Author.ToLower().Trim())).ToList<Book>();
        }
    }
}