using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_API2.Services
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public IEnumerable<string> Tags { get; set; }

        ///public List<String> Tags = new List<string>();
    }

    public class CustomResponse
    {
        public string Message { get; set; }

        public bool IsSuccessful { get; set; }
    }

    public class DemoSandboxService
    {
        private static List<UserDTO> UserList = new List<UserDTO>();

        public UserDTO GetOneById(int id)
        {
            return UserList.Find((user) => user.Id == id);
        }

        public UserDTO AddUser(UserDTO userData)
        {
            try
            {
                UserDTO userExists = UserList.Find((user) => user.Id == userData.Id);
                if (userExists != null)
                {
                    throw new Exception("This user already exists");
                }
                UserList.Add(userData);
                return userData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserDTO> GetAll()
        {
            try
            {
                return UserList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomResponse DeleteUser(int id)
        {
            try
            {
                List<UserDTO> allUsers = UserList.Where((user) => user.Id != id).ToList();

                UserList = allUsers;
                return new CustomResponse()
                {
                    IsSuccessful = true,
                    Message = "Delete works"
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
