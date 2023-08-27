namespace BookStore.User.Model
{
    public class ForgetPassword
    {
        public int UserID { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
