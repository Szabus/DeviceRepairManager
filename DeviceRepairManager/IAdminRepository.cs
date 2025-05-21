using DeviceRepairManager.Models;

namespace DeviceRepairManager.Repositories
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmins();
        Admin? GetAdminById(int id);
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
    }
}
