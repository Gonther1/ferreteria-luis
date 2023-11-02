using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Clases;

public class Cliente : BaseEntity
{
    public string Nombre { get; set; }
    public string Email { get; set; }
}
