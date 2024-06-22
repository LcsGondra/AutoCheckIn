using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.App.Dto
{
    public class PacienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataDeNascimento { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
