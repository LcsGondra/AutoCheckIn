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
    public class CheckInService
    {
        private CheckInRepo checkInRepo = new CheckInRepo();

        public async Task<CheckInDto> FazerCheckIn(CheckInDto dto)
        {
            CheckIn checkIn = await this.checkInRepo.
        }
    }
}
