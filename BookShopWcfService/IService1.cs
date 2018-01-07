using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookShopWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/Books", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindAllBooks();

        [OperationContract]
        [WebGet(UriTemplate = "/Categories", ResponseFormat = WebMessageFormat.Json)]
        string[] FindCategories();

        [OperationContract]
        [WebGet(UriTemplate = "/Book-category/{category}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindBookByCategory(string category);

        [OperationContract]
        [WebGet(UriTemplate = "/Book-title/{title}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindBookByTitle(string title);

        [OperationContract]
        [WebGet(UriTemplate = "/Book-author/{author}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook[] FindBookByAuthor(string author);

        [OperationContract]
        [WebGet(UriTemplate = "/Book/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFBook FindBookById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Update", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        int Update(WCFBook wcfbook);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class WCFBook
    {

        int bookID;
        string title;
        int categoryID;
        string isbn;
        string author;
        int stock;
        decimal price;

        [DataMember(Name = "id")]
        public int BookID
        {
            get
            {
                return bookID;
            }

            set
            {
                bookID = value;
            }
        }
        [DataMember(Name = "title")]
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        [DataMember(Name = "author")]
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }
        [DataMember(Name = "isbn")]
        public string ISBN
        {
            get
            {
                return isbn;
            }

            set
            {
                isbn = value;
            }
        }
        [DataMember(Name = "category")]

        public int Category
        {
            get
            {
                return categoryID;
            }

            set
            {
                categoryID = value;
            }
        }
        [DataMember(Name = "stock")]
        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }
        [DataMember(Name = "price")]
        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public static WCFBook MakeBook(Book book)
        {
            WCFBook wcfBook = new WCFBook();
            wcfBook.title = book.Title;
            wcfBook.bookID = book.BookID;
            wcfBook.author = book.Author;
            wcfBook.categoryID = book.CategoryID;
            wcfBook.isbn = book.ISBN;
            wcfBook.stock = book.Stock;
            wcfBook.price = book.Price;
            return wcfBook;
        }
    }
}
