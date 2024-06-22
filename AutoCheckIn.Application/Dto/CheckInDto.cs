using AutoCheckIn.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.App.Dto
{
    public class CheckInDto
    {
        public Guid Id { get; set; }
        public QuestionarioDto Questionario { get; set; }
        public PacienteDto Paciente { get; set; }
        public HospitalDto Hospital { get; set; }
        public string TipoEmergencia { get; set; }
        public string Prioridade { get; set; }
    }
}
