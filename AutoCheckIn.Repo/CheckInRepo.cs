using AutoCheckIn.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCheckIn.Repo
{
    public class CheckInRepo
    {
        private static List<CheckIn> CheckIns;

        public void Criar(CheckIn checkIn)
        {
            checkIn.Id = Guid.NewGuid();
            CheckIns.Add(checkIn);
        }
    }
}
