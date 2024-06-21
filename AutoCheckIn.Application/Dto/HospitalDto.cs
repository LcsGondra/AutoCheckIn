using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.App.Dto
{
    public class HospitalDto
    {
        public Guid Id { get; set; }
        public string Unidade { get; set; }
        public string Cidade { get; set; }
    }
}
