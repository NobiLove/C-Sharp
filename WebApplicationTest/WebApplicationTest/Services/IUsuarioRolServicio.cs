namespace WebApplicationTest.Services
{
    public interface IUsuarioRolServicio
    {
        Task<List<string>> GetRolesForUserAsync(string userName);
    }
}
