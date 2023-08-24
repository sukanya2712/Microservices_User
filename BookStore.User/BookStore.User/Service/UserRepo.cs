using BookStore.User.Context;
using BookStore.User.Entity;
using BookStore.User.Interface;
using BookStore.User.Migrations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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


         public string loginUser(string email, string password)
        {
            try
            {
                UserEntity result = _dbContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                if (result != null)
                {
                    return GenerateToken(result.Email, result.UserID);
                }

                return null;

            }catch(Exception ex) { throw ex; }
        }

        private string GenerateToken(string email, int userID)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",email),
                new Claim("UserID",userID.ToString())
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
