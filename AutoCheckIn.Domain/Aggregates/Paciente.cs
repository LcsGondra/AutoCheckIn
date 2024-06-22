using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Domain.Aggregates
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome{ get; set; }
        public string CPF { get; set; }
        public string DataDeNascimento { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public void Criar(string nome, string cpf, string nascimento, int idade, string email)
        {
            Nome = nome;
            CPF = cpf;
            DataDeNascimento = nascimento;
            Idade = idade;
            Email = email;
        }
    }
}
