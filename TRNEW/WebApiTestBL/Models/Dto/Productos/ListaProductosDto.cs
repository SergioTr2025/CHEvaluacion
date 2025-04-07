using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTestBL.Models.Dto.Productos
{
    public class ListaProductosDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Dictionary<string, object>? Data { get; set; }
    }
}
