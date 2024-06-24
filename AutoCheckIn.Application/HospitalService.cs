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
    public class HospitalService
    {
        public HospitalRepo Repo = new HospitalRepo();
        public HospitalService() 
        {
            Repo = new HospitalRepo();
        }

        public List<HospitalDto> GetHospitais()
        {
            var hospitais = this.Repo.ObterHospitais();
            var hospitaisDto = new List<HospitalDto>();
            foreach (var hospital in hospitais)
            {
                HospitalDto hospitalDto = new HospitalDto()
                {
                    Id = hospital.Id,
                    Unidade = hospital.Unidade,

                };
                hospitalDto.Endereco = new EnderecoDto()
                {
                    CEP = hospital.Endereco.CEP,
                    Rua = hospital.Endereco.Rua,
                    Numero = hospital.Endereco.Numero,
                    Complemento = hospital.Endereco.Complemento,
                    Bairro = hospital.Endereco.Bairro,
                    Cidade = hospital.Endereco.Cidade,
                    Estado = hospital.Endereco.Estado
                };
                hospitaisDto.Add(hospitalDto);
            };
            if (hospitais == null)
                return null;

            return hospitaisDto;

        }
    }
}
