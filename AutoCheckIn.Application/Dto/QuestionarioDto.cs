using AutoCheckIn.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.App.Dto
{
    public class QuestionarioDto
    {
        public Guid Id { get; set; }
        public List<PerguntasDto> Perguntas { get; set; }
    }
}
