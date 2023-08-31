namespace BookManagementCQRS.Model
{
    public class ResponseModel<T>
    {
        public String Message { get; set; }

        public T Data { get; set; }

        public bool Status { get; set; }
    }
}
