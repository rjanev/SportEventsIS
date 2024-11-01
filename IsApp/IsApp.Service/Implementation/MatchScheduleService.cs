using IsApp.Domain.Models;
using IsApp.Repository.Interface;
using IsApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Service.Implementation
{
    public class MatchScheduleService : IMatchScheduleService
    {
        private readonly IRepository<MatchSchedule> _matchScheduleRepository;

        public MatchScheduleService(IRepository<MatchSchedule> matchScheduleRepository)
        {
            _matchScheduleRepository = matchScheduleRepository;
        }

        public void CreateNewMatchSchedule(MatchSchedule p)
        {
            _matchScheduleRepository.Insert(p);
        }

        public void DeleteMatchSchedule(Guid id)
        {
            MatchSchedule ms= _matchScheduleRepository.Get(id);
            _matchScheduleRepository.Delete(ms);
        }

        public List<MatchSchedule> GetAllMatchSchedules()
        {
            return _matchScheduleRepository.GetAll().ToList();
        }

        public MatchSchedule GetDetailsForMatchSchedule(Guid? id)
        {
            return _matchScheduleRepository.Get(id);
        }

        public void UpdateExistingMatchSchedule(MatchSchedule p)
        {
            _matchScheduleRepository.Update(p);
        }
    }
}
