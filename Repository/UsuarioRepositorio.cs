using Microsoft.EntityFrameworkCore;
using Sistemas.Data;
using Sistemas.Models;
using Sistemas.Repository.Interface;

namespace Sistemas.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> AddUser(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var usuario = await GetById(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuário com o ID:{id} não foi encontrado no banco de dados");
            }

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<UsuarioModel>> GetAllUsers()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id)
        {
            var usuarioExistente = await GetById(id);
            if (usuarioExistente == null)
            {
                throw new KeyNotFoundException($"Usuário com o ID:{id} não foi encontrado no banco de dados");
            }

            usuarioExistente.Name = usuario.Name;
            usuarioExistente.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioExistente);
            await _dbContext.SaveChangesAsync();

            return usuarioExistente;
        }
    }
}
