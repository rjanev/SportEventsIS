using IsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Service.Interface
{
    public interface IMatchScheduleService
    {
        List<MatchSchedule> GetAllMatchSchedules();
        MatchSchedule GetDetailsForMatchSchedule(Guid? id);
        void CreateNewMatchSchedule(MatchSchedule p);
        void UpdateExistingMatchSchedule(MatchSchedule p);
        void DeleteMatchSchedule(Guid id);
    }
}
