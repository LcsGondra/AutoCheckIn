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
                    Endereco = new Endereco()
                    {
                        CEP = "12345-678",
                        Rua = "avenida das americas",
                        Numero = 1234,
                        Complemento = "",
                        Bairro = "barra de tijuca",
                        Cidade = "Rio de Janeiro",
                        Estado = "RJ"
                    }
                });

                Hospitais.Add(new Hospital()
                {
                    Id = new Guid("EE9A04A1-72FD-48E8-A376-A3BF0563B050"),
                    Unidade = "Hospital RJ 2",
                    Endereco = new Endereco()
                    {
                        CEP = "12345-679",
                        Rua = "Rua dos hospitais",
                        Numero = 123,
                        Complemento = "",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        Estado = "RJ"
                    }
                });
                Hospitais.Add(new Hospital()
                {
                    Id = new Guid("05A1521A-062A-4878-8524-DB6493823A64"),
                    Unidade = "Hospital SP 1",
                    Endereco = new Endereco()
                    {
                        CEP = "98765-432",
                        Rua = "Rua dos hospitais",
                        Numero = 321,
                        Complemento = "",
                        Bairro = "Guarulhos",
                        Cidade = "Sao Paulo",
                        Estado = "SP"
                    }
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
