using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Domain.Aggregates
{
    public class Hospital
    {
        public Guid Id { get; set; }
        public string Unidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
    }
}
