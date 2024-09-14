using System;
using System.Collections.Generic;

namespace WebApplicationTest.EFModels;

public partial class RolUsuario
{
    public int IdRolUsuario { get; set; }

    public int IdRol { get; set; }

    public int IdUsuario { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
