using DeviceRepairManager.Models;
using System.Collections.Generic;


namespace DeviceRepairManager.Repositories
{
    public interface IDeviceRepository
    {
        void AddDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(int deviceId);
        Device? GetDeviceById(int deviceId);
        List<Device> GetAllDevices();
        List<Device> GetDevicesByCustomerId(int customerId);
    }
}
