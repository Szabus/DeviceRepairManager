using DeviceRepairManager.Models;

namespace DeviceRepairManager.Repositories
{
    public interface ITechnicianRepository
    {
        List<Technician> GetAllTechnicians();
        Technician? GetTechnicianById(int id);
        void AddTechnician(Technician technician);
        void UpdateTechnician(Technician technician);
        void DeleteTechnician(int id);
    }
}
