using BookStore.User.Context;
using BookStore.User.Entity;
using BookStore.User.Interface;

namespace BookStore.User.Service
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserRepo(UserDBContext _dbContext, IConfiguration _configuration)
        {
            this._dbContext = _dbContext;
            this._configuration = _configuration;
        }

        public UserEntity addUser(UserEntity user)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
               
                userEntity.Password = EncodePasswordToBase64(user.Password);
                userEntity.CreatedAt = DateTime.Now;
                userEntity.UpdatedAt = DateTime.Now;
                userEntity.Address = user.Address;
                _dbContext.Users.Add(userEntity);
                _dbContext.SaveChanges();
                return userEntity;

            }
            catch (Exception ex) { throw ex; }
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}
