using AutoCheckIn.App.Dto;
using AutoCheckIn.Domain.Aggregates;
using AutoCheckIn.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.App
{
    public class PacienteService
    {
        public PacienteRepo Repo = new PacienteRepo();
        public PacienteService() { }
        public PacienteDto Criar(PacienteDto dto)
        {
            Paciente paciente = new Paciente()
            {
                Nome = dto.Nome,
                CPF = dto.CPF,
                DataDeNascimento = dto.DataDeNascimento,
                Idade = dto.Idade,
                Email = dto.Email
            };
            paciente.Endereco = new Endereco()
            {
                CEP = dto.Endereco.CEP,
                Rua = dto.Endereco.Rua,
                Numero = dto.Endereco.Numero,
                Complemento = dto.Endereco.Complemento,
                Bairro = dto.Endereco.Bairro,
                Cidade = dto.Endereco.Cidade,
                Estado = dto.Endereco.Estado
            };
            Repo.Criar(paciente);
            dto.Id = paciente.Id;

            return dto;
        }
    }
}
