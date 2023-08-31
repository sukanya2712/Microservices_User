using BookStore.Book.Context;
using BookStore.Book.Entity;
using BookStore.Book.Interface;

namespace BookStore.Book.Service
{
    // Implementation of IBookRepo interface
    public class BookRepo : IBookRepo
    {
        // Private field to hold the database context
        private readonly BookDBContext dbContext;

        // Constructor that injects the database context
        public BookRepo(BookDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Method to add a book to the database
        public BookEntity addBook(BookEntity book)
        {
            // Create a new instance of BookEntity
            BookEntity bookEntity = new BookEntity();

            // Copy properties from the input book to the new bookEntity
            bookEntity.Author = book.Author;
            bookEntity.Title = book.Title;
            bookEntity.Description = book.Description;
            bookEntity.Genre = book.Genre;
            bookEntity.DiscountedPri=book.DiscountedPri;
            bookEntity.BookQty = book.BookQty;
            bookEntity.ListPrice = book.ListPrice;
            bookEntity.ratings = book.ratings;
            // Add the new bookEntity to the Books DbSet
            dbContext.Books.Add(bookEntity);
            // Save changes to the database
            dbContext.SaveChanges();
            // Return the newly added bookEntity
            return bookEntity;
        }



        // Method to delete a book by its ID
        public bool deleteBook(int bookId)
        {
            // Find the book to delete by its ID
            BookEntity delete = dbContext.Books.Where(x => x.BookId == bookId).FirstOrDefault();

            // If the book is found
            if (delete != null)
            {
                // Remove the book from the Books DbSet
                dbContext.Books.Remove(delete);
                // Save changes to the database
                dbContext.SaveChanges();
                // Indicate successful deletion
                return true;
            }
            // Indicate deletion failure (book not found)
            return false;
        }



        // Method to retrieve a book by its ID
        public BookEntity getBookbyId(int id)
        {
            // Find the book by its ID
            BookEntity bookDetail = dbContext.Books.Where(x => x.BookId == id).FirstOrDefault();

            // If the book is found
            if (bookDetail != null)
            {
                // Return the book
                return bookDetail;
            }

            return null;
        }



        // Method to retrieve all books
        public List<BookEntity> getAllBooks()
        {
            // Get a list of all books from the database
            List<BookEntity> list = dbContext.Books.ToList();

            // If the list is not empty
            if (list != null)
            {
                return list;
            }
            // If the list is empty
            return null;
        }
    }
}
