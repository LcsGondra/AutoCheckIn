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
                Altura = dto.Altura,
                Peso = dto.Peso,
                DataDeNascimento = dto.DataDeNascimento,
                TipoSanguineo = dto.TipoSanguineo
            };

            Repo.Criar(paciente);
            dto.Id = paciente.Id;

            return dto;
        }
    }
}
