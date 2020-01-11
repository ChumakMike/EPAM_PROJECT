using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelsDTO;


namespace BLL.Interfaces {
    public interface IUserService : IDisposable {
        Task Create(UserDTO userDTO);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetUserById(string id);
        void Remove(UserDTO userDTO);
        void Update(UserDTO userDTO);
        Task<UserDTO> Auth(string userName, string password);
    }
}
