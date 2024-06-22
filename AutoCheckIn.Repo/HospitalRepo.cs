using AutoCheckIn.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Repo
{
    public class HospitalRepo
    {
        private static List<Hospital> Hospitais;
        public HospitalRepo()
        {
            if (Hospitais == null)
            {
                Hospitais = new List<Hospital>();
                Hospitais.Add(new Hospital()
                {
                    Id = new Guid("ACFDB825-3A85-4B50-9DA1-20C22915FB0F"),
                    Unidade = "Hospital RJ 1",
                    Estado = "Rio de Janeiro",
                    Endereco = "avenida das americas 1234, Rio de janeiro",
                    CEP = "12345-678"
                });
                Hospitais.Add(new Hospital()
                {
                    Id = new Guid("EE9A04A1-72FD-48E8-A376-A3BF0563B050"),
                    Unidade = "Hospital RJ 2",
                    Estado = "Rio de Janeiro",
                    Endereco = "Rua dos hospitais 123, Rio de janeiro",
                    CEP = "12345-679"
                });
                Hospitais.Add(new Hospital()
                {
                    Id = new Guid("05A1521A-062A-4878-8524-DB6493823A64"),
                    Unidade = "Hospital SP 1",
                    Estado = "São Paulo",
                    Endereco = "Rua dos hospitais 321, Guarulhos",
                    CEP = "98765-432"
                });
            }
        }

        public Hospital ObterHospitalId(Guid id)
        {
            return Hospitais.FirstOrDefault(x => x.Id == id);
        }

        public List<Hospital> ObterHospitais()
        {
            var hospitais = Hospitais;
            return hospitais;

        }

    }
}
