using Microsoft.AspNetCore.Identity;

namespace ArriendoPocket.Data
{
    public static class DBInitializer
    {
        public static async Task SembrarRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = { "Arrendador", "Inquilino", "CorredorInmueble" };

            foreach (var rol in roles)
            {
                if (!await roleManager.RoleExistsAsync(rol))
                {
                    await roleManager.CreateAsync(new IdentityRole(rol));
                }
            }
        }
    }
}
