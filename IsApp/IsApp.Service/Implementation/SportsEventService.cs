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
    public class SportsEventService : ISportsEventService
    {
        private readonly IRepository<SportsEvent> _sportsEventRepository;

        public SportsEventService(IRepository<SportsEvent> sportsEventRepository)
        {
            _sportsEventRepository = sportsEventRepository;
        }

        public void CreateNewSportsEvent(SportsEvent p)
        {
            _sportsEventRepository.Insert(p);
        }

        public void DeleteSportsEvent(Guid id)
        {
            SportsEvent se=_sportsEventRepository.Get(id);
            _sportsEventRepository.Delete(se);
        }

        public List<SportsEvent> GetAllSportsEvents()
        {
            return _sportsEventRepository.GetAll().ToList();
        }

        public SportsEvent GetDetailsForSportsEvent(Guid? id)
        {
            return _sportsEventRepository.Get(id);
        }

        public void UpdateExistingSportsEvent(SportsEvent p)
        {
            _sportsEventRepository.Update(p);
        }
    }
}
