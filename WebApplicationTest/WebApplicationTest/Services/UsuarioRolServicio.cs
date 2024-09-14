using Microsoft.EntityFrameworkCore;
using WebApplicationTest.EFModels;
using WebApplicationTest.Models;

namespace WebApplicationTest.Services
{
    public class UsuarioRolServicio : IUsuarioRolServicio
    {
        private readonly TestDbContext _context;

        public UsuarioRolServicio(TestDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetRolesForUserAsync(string userName)
        {
            // Buscar el usuario en la tabla de usuarios
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreWindows == userName);

            if (user == null)
            {
                // Si el usuario no existe en la base de datos, no hay roles que asignar
                return new List<string>();
            }

            // Buscar los roles asociados al usuario en la tabla roles_usuario
            var roles = await (from rol in _context.Rols
                               join rolusuario in _context.RolUsuarios on rol.IdRol equals rolusuario.IdRol
                               where rolusuario.IdUsuario == user.IdUsuario
                               select rol.Nombre).ToListAsync();

            return roles;
        }
    }
}
