using Sistemas.Models;

namespace Sistemas.Repository.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAllUsers();

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> AddUser(UsuarioModel usuario);

        Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id);

        Task<bool> DeleteUser(int id);
    }
}
