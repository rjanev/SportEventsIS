using IsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Service.Interface
{
    public interface ISportsEventService
    {
        List<SportsEvent> GetAllSportsEvents();
        SportsEvent GetDetailsForSportsEvent(Guid? id);
        void CreateNewSportsEvent(SportsEvent p);
        void UpdateExistingSportsEvent(SportsEvent p);
        void DeleteSportsEvent(Guid id);
    }
}
