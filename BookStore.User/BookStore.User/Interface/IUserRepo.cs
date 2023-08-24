using BookStore.User.Entity;

namespace BookStore.User.Interface
{
    public interface IUserRepo
    {
        public UserEntity addUser(UserEntity user);
    }
}