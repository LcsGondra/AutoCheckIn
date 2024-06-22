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
                DataDeNascimento = dto.Paciente.DataDeNascimento,
                Idade = dto.Paciente.Idade,
                Email = dto.Paciente.Email
            };
            paciente.Endereco = new Endereco()
            {
                CEP =  dto.Paciente.Endereco.CEP,
                Rua = dto.Paciente.Endereco.Rua,
                Numero = dto.Paciente.Endereco.Numero,
                Complemento = dto.Paciente.Endereco.Complemento,
                Bairro = dto.Paciente.Endereco.Bairro,
                Cidade = dto.Paciente.Endereco.Cidade,
                Estado = dto.Paciente.Endereco.Estado
                    
            };
            checkIn.AdicionarPaciente(paciente);

            Hospital hospital = new Hospital()
            {
                Id = dto.Hospital.Id,
                Unidade = dto.Hospital.Unidade
            };
            paciente.Endereco = new Endereco()
            {
                CEP = dto.Hospital.Endereco.CEP,
                Rua = dto.Hospital.Endereco.Rua,
                Numero = dto.Hospital.Endereco.Numero,
                Complemento = dto.Hospital.Endereco.Complemento,
                Bairro = dto.Hospital.Endereco.Bairro,
                Cidade = dto.Hospital.Endereco.Cidade,
                Estado = dto.Hospital.Endereco.Estado
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