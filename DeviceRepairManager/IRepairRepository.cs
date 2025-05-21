using DeviceRepairManager.Models;
using System.Collections.Generic;

namespace DeviceRepairManager.Repositories
{
    public interface IRepairRepository
    {
        List<Repair> GetAllRepairs();
        Repair? GetRepairById(int id);
        void AddRepair(Repair repair);
        void UpdateRepair(Repair repair);
        void DeleteRepair(int id);
    }
}
