using System.Security.Claims;
using WebApplicationTest.Services;

namespace WebApplicationTest.Middlewares
{
    public class UsuarioRolMiddleware
    {
        private readonly RequestDelegate _next;

        public UsuarioRolMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUsuarioRolServicio usuarioRolServicio)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                string[] parts = context.User.Identity.Name.Split('\\');

                var domain = parts[0];
                //var userName = parts[1];
                var userName = "Tomy";

                // Obtener los roles del usuario desde la base de datos
                var roles = await usuarioRolServicio.GetRolesForUserAsync(userName);

                if (roles != null && roles.Any())
                {
                    // Crear una lista de claims basados en los roles
                    var claims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

                    // Añadir los roles a la identidad del usuario
                    var appIdentity = new ClaimsIdentity(claims);
                    context.User.AddIdentity(appIdentity);
                }
            }

            await _next(context);
        }
    }
}
