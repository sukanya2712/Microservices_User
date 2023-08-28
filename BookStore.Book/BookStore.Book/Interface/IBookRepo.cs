using BookStore.Book.Entity;

namespace BookStore.Book.Interface
{
    public interface IBookRepo
    {
        public BookEntity addBook(BookEntity book);
        public bool deleteBook(int bookId);
        public List<BookEntity> getAllBooks();
        public BookEntity getBookbyId(int id);
    }
}