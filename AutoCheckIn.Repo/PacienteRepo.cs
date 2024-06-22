using AutoCheckIn.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Repo
{
    public class PacienteRepo
    {
        private static List<Paciente> pacientes = new List<Paciente>();

        public Paciente ObterPaciente(Guid id)
        {
            return pacientes.FirstOrDefault(x => x.Id == id);
        }

        public void Criar(Paciente paciente)
        {
            paciente.Id = Guid.NewGuid();
            pacientes.Add(paciente);
        }
    }
}
