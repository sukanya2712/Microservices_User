using BookStore.Book.Context;
using BookStore.Book.Entity;
using BookStore.Book.Interface;

namespace BookStore.Book.Service
{
    public class BookRepo : IBookRepo
    {
        private readonly BookDBContext dbContext;
        public BookRepo(BookDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BookEntity addBook(BookEntity book)
        {
            BookEntity bookEntity = new BookEntity();
            bookEntity.Author = book.Author;
            bookEntity.Title = book.Title;
            bookEntity.Description = book.Description;
            bookEntity.Genre = book.Genre;
            bookEntity.DiscountedPri=book.DiscountedPri;
            bookEntity.BookQty = book.BookQty;
            bookEntity.ListPrice = book.ListPrice;
            bookEntity.ratings = book.ratings;
            dbContext.Books.Add(bookEntity);
            dbContext.SaveChanges();
            return bookEntity;
        }

        public bool deleteBook(int bookId)
        {
            BookEntity delete = dbContext.Books.Where(x => x.BookId == bookId).FirstOrDefault();

            if (delete != null)
            {
                dbContext.Books.Remove(delete);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public BookEntity getBookbyId(int id)
        {
            BookEntity bookDetail = dbContext.Books.Where(x => x.BookId == id).FirstOrDefault();

            if (bookDetail != null)
            {
                return bookDetail;
            }

            return null;
        }

        public List<BookEntity> getAllBooks()
        {
            List<BookEntity> list = dbContext.Books.ToList();

            if (list != null)
            {
                return list;
            }
            return null;
        }
    }
}
