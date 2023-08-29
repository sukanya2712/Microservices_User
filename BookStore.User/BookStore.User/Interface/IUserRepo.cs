using BookStore.User.Entity;
using BookStore.User.Model;

namespace BookStore.User.Interface
{
    public interface IUserRepo
    {
        public UserEntity addUser(UserEntity user);
        public string loginUser(string email, string password);

        public ForgetPassword UserForgotPassword(string email);

        public bool CheckEmail(string email);

        public ResetPassword ResetPassword(string email, ResetPassword resetPassword);

        public UserEntity GetUserProfile(int userID);
    }
}