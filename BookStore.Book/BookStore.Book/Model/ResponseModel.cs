namespace BookStore.Book.Model
{
    public class ResponseModel<T>
    {
        public bool Status { get; set; } = true;
        public string Message { get; set; } = "Sucessful";
        public T Data { get; set; }
    }
}
