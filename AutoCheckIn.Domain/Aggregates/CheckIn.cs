using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Domain.Aggregates
{
    public class CheckIn
    {
        public Guid Id { get; set; }
        public Questionario Questionario { get; set; }
        public Paciente Paciente { get; set; }
        public Hospital Hospital {  get; set; }
        public string TipoEmergencia { get; set; }
        public string Prioridade { get; set; }

        public CheckIn() { }

        public void AdicionarPaciente(Paciente paciente)
        {
            Paciente = paciente;
        }
        public void AdicionarQuestionario(Questionario questionario)
        {
            Questionario = questionario;
        }
        public void AdicionarHospital(Hospital hospital)
        {
            Hospital = hospital;
        }
    }
}
