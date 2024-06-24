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

        public class RotaEmergencia
        {
            public string TipoEmergencia { get; set; }
            public string Prioridade { get; set; }
        }

        public async Task<CheckInDto> FazerCheckIn(CheckInDto dto)
        {
            CheckIn checkIn = new CheckIn()
            {
                Id = Guid.NewGuid()
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
                Id = Guid.NewGuid()
            };
            if (dto.Questionario.Perguntas != null)
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
            RotaEmergencia rotaEmergencia = DeterminarRota(questionario, paciente.Idade);

            checkIn.TipoEmergencia = rotaEmergencia.TipoEmergencia;
            checkIn.Prioridade = rotaEmergencia.Prioridade;
            checkInRepo.Criar(checkIn);
            dto.Questionario.Id = questionario.Id;
            dto.TipoEmergencia = rotaEmergencia.TipoEmergencia;
            dto.Prioridade = rotaEmergencia.Prioridade;
            dto.Id = checkIn.Id;

            return dto;
        }

        public static RotaEmergencia DeterminarRota(Questionario questionario, int idade)
        {
            var perguntas = questionario.Perguntas;
            var temDiabetesOuHipertensao = perguntas.Any(p => p.Pergunta == "Doenças Prévias" && p.Resposta == "Sim");
            var idadeAcimaDe40 = idade > 40;
            var caracteristicasDorNoPeito = perguntas.Any(p => p.Pergunta == "Dor no peito" && (p.Resposta.Contains("aperto") || p.Resposta.Contains("pontada") || p.Resposta.Contains("queimação")));

            var dificuldadeParaFalar = perguntas.Any(p => p.Pergunta == "Dificuldade para falar" && p.Resposta == "Sim");
            var perdaDeMovimento = perguntas.Any(p => p.Pergunta == "Perda de movimento nos braços ou nas pernas" && p.Resposta == "Sim");
            var assimetriaFacial = perguntas.Any(p => p.Pergunta == "Assimetria Facial" && p.Resposta == "Sim");
            var dorDeCabecaSintoma = perguntas.Any(p => p.Pergunta == "Dor de cabeça de inicio súbito e forte intensidade" && p.Resposta == "Sim");

            var temTosse = perguntas.Any(p => p.Pergunta == "Tosse" && p.Resposta == "Sim");
            var congestaoNasal = perguntas.Any(p => p.Pergunta == "Congestão Nasal" && p.Resposta == "Sim");
            var coriza = perguntas.Any(p => p.Pergunta == "Coriza" && p.Resposta == "Sim");
            var dorDeGarganta = perguntas.Any(p => p.Pergunta == "Dor de Garganta" && p.Resposta == "Sim");

            var temDiarreia = perguntas.Any(p => p.Pergunta == "Diarreia" && p.Resposta == "Sim");
            var dorAbdominal = perguntas.Any(p => p.Pergunta == "Dor abdominal" && p.Resposta == "Sim");
            var vomitos = perguntas.Any(p => p.Pergunta == "Vômitos / enjoo" && p.Resposta == "Sim");

            var temFebre = perguntas.Any(p => p.Pergunta == "Febre" && p.Resposta == "Sim");
            var dorNoCorpo = perguntas.Any(p => p.Pergunta == "Dor no Corpo" && p.Resposta == "Sim");
            var dorNasArticulacoes = perguntas.Any(p => p.Pergunta == "Dor nas articulações" && p.Resposta == "Sim");
            var dorDeCabecaAtrasDosOlhos = perguntas.Any(p => p.Pergunta == "Dor de cabeça / atrás dos olhos" && p.Resposta == "Sim");
            var malEstarGeral = perguntas.Any(p => p.Pergunta == "Mal estar geral" && p.Resposta == "Sim");

            var temArdenciaAoUrinar = perguntas.Any(p => p.Pergunta == "Ardência para urinar" && p.Resposta == "Sim");
            var dorLombar = perguntas.Any(p => p.Pergunta == "Dor lombar" && p.Resposta == "Sim");

            if (caracteristicasDorNoPeito && (temDiabetesOuHipertensao || idadeAcimaDe40))
            {
                return new RotaEmergencia { TipoEmergencia = "Possível Rota Assistencial de Dor Torácica", Prioridade = "ALTA" };
            }
            else if (dificuldadeParaFalar || perdaDeMovimento || assimetriaFacial || dorDeCabecaSintoma)
            {
                return new RotaEmergencia { TipoEmergencia = "Possível Rota Assistencial de Acidente Vascular Cerebral", Prioridade = "ALTA" };
            }
            else if (temTosse || congestaoNasal || coriza || dorDeGarganta)
            {
                return new RotaEmergencia { TipoEmergencia = "Possível Rota Assistencial de Infecção de Vias Aéreas", Prioridade = "MÉDIA" };
            }
            else if (temDiarreia || dorAbdominal || vomitos)
            {
                return new RotaEmergencia { TipoEmergencia = "Possível Rota Assistencial de Infecção Gastrointestinal", Prioridade = "MÉDIA" };
            }
            else if (temFebre && (dorNoCorpo || dorNasArticulacoes || dorDeCabecaAtrasDosOlhos || malEstarGeral))
            {
                return new RotaEmergencia { TipoEmergencia = "Possível Rota Assistencial de Arboviroses", Prioridade = "MÉDIA" };
            }
            else if (temArdenciaAoUrinar)
            {
                return new RotaEmergencia { TipoEmergencia = "Possível Rota Assistencial de Infecção Urinária", Prioridade = "BAIXA" };
            }
            else if (dorLombar)
            {
                return new RotaEmergencia { TipoEmergencia = "Possível Rota Assistencial de Lombalgia", Prioridade = "BAIXA" };
            }
            else
            {
                return new RotaEmergencia { TipoEmergencia = "Rota não determinada. Avaliação adicional necessária.", Prioridade = "INDEFINIDA" };
            }
        }
    }
    


}