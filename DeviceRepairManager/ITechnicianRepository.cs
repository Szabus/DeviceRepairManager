using DeviceRepairManager.Models;

namespace DeviceRepairManager.Repositories
{
    public interface ITechnicianRepository
    {
        public List<Technician> GetAllTechnicians();

        public void AddTechnician(Technician tech);

        public void UpdateTechnician(Technician tech);

        public void DeleteTechnician(int technicianId);

    }
}
