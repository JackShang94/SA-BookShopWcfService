using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookShopWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public WCFBook[] FindAllBooks()
        {
            return ConvertFromBookList(BusinessLogic.SearchAllBooks());
        }

        public string[] FindCategories()
        {
            List<Category> c = BusinessLogic.FindAllCategories();
            string[] categories = new string[c.Count];
            for (int i = 0; i < categories.Length; i++)
            {
                categories[i] = c[i].Name;
            }
            return categories;
        }

        public WCFBook[] FindBookByCategory(string category)
        {
            return ConvertFromBookList(BusinessLogic.SearchBookByCategory(category));
        }

        public WCFBook[] FindBookByTitle(string title)
        {
            return ConvertFromBookList(BusinessLogic.SearchBookByTitle(title));

        }

        public WCFBook[] FindBookByAuthor(string author)
        {
            return ConvertFromBookList(BusinessLogic.SearchBookByAuthor(author));
        }

        public WCFBook FindBookById(string id)
        {
            int bookId;
            bool result = Int32.TryParse(id, out bookId);
            if (result)
            {
                return WCFBook.MakeBook(BusinessLogic.SearchBookByBookId(bookId));
            }
            return null;
        }

        //helper method
        private WCFBook[] ConvertFromBookList(List<Book> bList)
        {
            WCFBook[] bk = new WCFBook[bList.Count];
            for (int i = 0; i < bList.Count; i++)
            {
                bk[i] = WCFBook.MakeBook(bList[i]);
            }
            return bk;
        }

        public int Update(WCFBook wcfbook)
        {
             return   BusinessLogic.UpdateBook(wcfbook.BookID,wcfbook.Title,wcfbook.Category,wcfbook.ISBN,wcfbook.Author,wcfbook.Stock,wcfbook.Price);
        }
    }
}
