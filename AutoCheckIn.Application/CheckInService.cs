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
    public class CheckInService
    {
        private CheckInRepo checkInRepo = new CheckInRepo();
        private PacienteRepo pacienteRepo = new PacienteRepo();

        public CheckInService() { }

        public async Task<CheckInDto> FazerCheckIn(CheckInDto dto)
        {
            CheckIn checkIn = new CheckIn()
            {
                TipoEmergencia = dto.TipoEmergencia,
                Prioridade = dto.Prioridade
            };

            Paciente paciente = new Paciente()
            {
                Id = dto.Paciente.Id,
                Nome = dto.Paciente.Nome,
                CPF = dto.Paciente.CPF,
                Altura = dto.Paciente.Altura,
                Peso = dto.Paciente.Peso,
                DataDeNascimento = dto.Paciente.DataDeNascimento,
                TipoSanguineo = dto.Paciente.TipoSanguineo
            };
            checkIn.AdicionarPaciente(paciente);

            Hospital hospital = new Hospital()
            {
                Id = dto.Hospital.Id,
                Unidade = dto.Hospital.Unidade,
                Estado = dto.Hospital.Estado,
                Endereco = dto.Hospital.Endereco,
                CEP = dto.Hospital.CEP
            };
            checkIn.AdicionarHospital(hospital);

            Questionario questionario = new Questionario()
            {
                Id = dto.Questionario.Id
            };
            if(dto.Questionario.Perguntas != null)
            {
                foreach(var item in dto.Questionario.Perguntas)
                {
                    questionario.AdicionarPerguntas(new PerguntaResposta()
                    {
                        Numero = item.Numero,
                        Pergunta = item.Pergunta,
                        Resposta = item.Resposta
                    });
                }
            }
            checkIn.AdicionarQuestionario(questionario);

            checkInRepo.Criar(checkIn);
            dto.Id = checkIn.Id;

            return dto;
        }
    }
}