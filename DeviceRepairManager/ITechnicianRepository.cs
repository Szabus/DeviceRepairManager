using DeviceRepairManager.Models;

namespace DeviceRepairManager.Repositories
{
    public interface ITechnicianRepository
    {
        public void UpdateRepairStatus(int repairId, string newStatus, string notes = null, DateTime? completionDate = null);

    }
}
