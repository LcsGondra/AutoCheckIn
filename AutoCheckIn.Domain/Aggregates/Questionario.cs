using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Domain.Aggregates
{
    public class Questionario
    {
        public Guid Id { get; set; }
        public List<PerguntaResposta> Perguntas { get; set; }

        public Questionario()
        {
            Perguntas = new List<PerguntaResposta>();
        }

        public void AdicionarPerguntas(PerguntaResposta perguntas)
        {
            Perguntas.Add(perguntas);
        }
    }
}
