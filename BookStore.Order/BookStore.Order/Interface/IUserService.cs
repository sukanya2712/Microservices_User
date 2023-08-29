using BookStore.Order.Entity;

namespace BookStore.Order.Interface
{
    public interface IUserService
    {
        Task<UserEntity> GetUserDetails(string token);
    }
}