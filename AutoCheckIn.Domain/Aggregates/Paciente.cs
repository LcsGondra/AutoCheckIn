using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Domain.Aggregates
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome{ get; set; }
        public string CPF { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set;}
        public int DataDeNascimento { get; set;}

    }
}
