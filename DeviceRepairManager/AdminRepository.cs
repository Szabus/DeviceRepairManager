using DeviceRepairManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class AdminRepository
{
    private readonly SQLiteConnection _conn;

    public AdminRepository(SQLiteConnection connection)
    {
        _conn = connection;
    }

    // Ügyfelek kezelése

    public List<Customer> GetAllCustomers()
    {
        var customers = new List<Customer>();

        using var cmd = new SQLiteCommand("SELECT * FROM Customers", _conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            customers.Add(new Customer
            {
                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                Name = reader["Name"].ToString(),
                ContactInfo = reader["ContactInfo"].ToString(),
                Address = reader["Address"].ToString(),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString()),
                IsVIP = Convert.ToBoolean(reader["IsVIP"]),
                PasswordHash = reader["PasswordHash"].ToString()
            });
        }
        return customers;
    }

    public Customer GetCustomerById(int customerId)
    {
        using var cmd = new SQLiteCommand("SELECT * FROM Customers WHERE CustomerId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", customerId);
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Customer
            {
                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                Name = reader["Name"].ToString(),
                ContactInfo = reader["ContactInfo"].ToString(),
                Address = reader["Address"].ToString(),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString()),
                IsVIP = Convert.ToBoolean(reader["IsVIP"]),
                PasswordHash = reader["PasswordHash"].ToString()
            };
        }
        return null;
    }

    public void AddCustomer(Customer customer)
    {
        using var cmd = new SQLiteCommand(@"
            INSERT INTO Customers (Name, ContactInfo, Address, Email, PhoneNumber, RegistrationDate, IsVIP, PasswordHash)
            VALUES (@name, @contact, @address, @email, @phone, @regDate, @isVip, @password)", _conn);

        cmd.Parameters.AddWithValue("@name", customer.Name);
        cmd.Parameters.AddWithValue("@contact", customer.ContactInfo);
        cmd.Parameters.AddWithValue("@address", customer.Address);
        cmd.Parameters.AddWithValue("@email", customer.Email);
        cmd.Parameters.AddWithValue("@phone", customer.PhoneNumber);
        cmd.Parameters.AddWithValue("@regDate", customer.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.Parameters.AddWithValue("@isVip", customer.IsVIP ? 1 : 0);
        cmd.Parameters.AddWithValue("@password", customer.PasswordHash);

        cmd.ExecuteNonQuery();
    }

    public void UpdateCustomer(Customer customer)
    {
        using var cmd = new SQLiteCommand(@"
            UPDATE Customers SET
                Name = @name,
                ContactInfo = @contact,
                Address = @address,
                Email = @email,
                PhoneNumber = @phone,
                IsVIP = @isVip,
                PasswordHash = @password
            WHERE CustomerId = @id", _conn);

        cmd.Parameters.AddWithValue("@name", customer.Name);
        cmd.Parameters.AddWithValue("@contact", customer.ContactInfo);
        cmd.Parameters.AddWithValue("@address", customer.Address);
        cmd.Parameters.AddWithValue("@email", customer.Email);
        cmd.Parameters.AddWithValue("@phone", customer.PhoneNumber);
        cmd.Parameters.AddWithValue("@isVip", customer.IsVIP ? 1 : 0);
        cmd.Parameters.AddWithValue("@password", customer.PasswordHash);
        cmd.Parameters.AddWithValue("@id", customer.CustomerId);

        cmd.ExecuteNonQuery();
    }

    public void DeleteCustomer(int customerId)
    {
        using var cmd = new SQLiteCommand("DELETE FROM Customers WHERE CustomerId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", customerId);
        cmd.ExecuteNonQuery();
    }


    // Szervizesek kezelése (Technicians)

    public List<Technician> GetAllTechnicians()
    {
        var techs = new List<Technician>();

        using var cmd = new SQLiteCommand("SELECT * FROM Technicians", _conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            techs.Add(new Technician
            {
                TechnicianId = Convert.ToInt32(reader["TechnicianId"]),
                Name = reader["Name"].ToString(),
                Expertise = reader["Expertise"].ToString(),
                IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                TotalWorkHours = Convert.ToDouble(reader["TotalWorkHours"]),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                HireDate = DateTime.Parse(reader["HireDate"].ToString()),
                IsOnLeave = Convert.ToBoolean(reader["IsOnLeave"]),
                CompletedRepairs = Convert.ToInt32(reader["CompletedRepairs"]),
                Shift = reader["Shift"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString()
            });
        }
        return techs;
    }

    public Technician GetTechnicianById(int technicianId)
    {
        using var cmd = new SQLiteCommand("SELECT * FROM Technicians WHERE TechnicianId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", technicianId);
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Technician
            {
                TechnicianId = Convert.ToInt32(reader["TechnicianId"]),
                Name = reader["Name"].ToString(),
                Expertise = reader["Expertise"].ToString(),
                IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                TotalWorkHours = Convert.ToDouble(reader["TotalWorkHours"]),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                HireDate = DateTime.Parse(reader["HireDate"].ToString()),
                IsOnLeave = Convert.ToBoolean(reader["IsOnLeave"]),
                CompletedRepairs = Convert.ToInt32(reader["CompletedRepairs"]),
                Shift = reader["Shift"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString()
            };
        }
        return null;
    }

    public void AddTechnician(Technician tech)
    {
        using var cmd = new SQLiteCommand(@"
            INSERT INTO Technicians (Name, Expertise, IsAvailable, TotalWorkHours, Email, PhoneNumber, HireDate, IsOnLeave, CompletedRepairs, Shift, PasswordHash)
            VALUES (@name, @expertise, @available, @hours, @email, @phone, @hireDate, @onLeave, @completed, @shift, @password)", _conn);

        cmd.Parameters.AddWithValue("@name", tech.Name);
        cmd.Parameters.AddWithValue("@expertise", tech.Expertise);
        cmd.Parameters.AddWithValue("@available", tech.IsAvailable ? 1 : 0);
        cmd.Parameters.AddWithValue("@hours", tech.TotalWorkHours);
        cmd.Parameters.AddWithValue("@email", tech.Email);
        cmd.Parameters.AddWithValue("@phone", tech.PhoneNumber);
        cmd.Parameters.AddWithValue("@hireDate", tech.HireDate.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.Parameters.AddWithValue("@onLeave", tech.IsOnLeave ? 1 : 0);
        cmd.Parameters.AddWithValue("@completed", tech.CompletedRepairs);
        cmd.Parameters.AddWithValue("@shift", tech.Shift);
        cmd.Parameters.AddWithValue("@password", tech.PasswordHash);

        cmd.ExecuteNonQuery();
    }

    public void UpdateTechnician(Technician tech)
    {
        using var cmd = new SQLiteCommand(@"
            UPDATE Technicians SET
                Name = @name,
                Expertise = @expertise,
                IsAvailable = @available,
                TotalWorkHours = @hours,
                Email = @email,
                PhoneNumber = @phone,
                HireDate = @hireDate,
                IsOnLeave = @onLeave,
                CompletedRepairs = @completed,
                Shift = @shift,
                PasswordHash = @password
            WHERE TechnicianId = @id", _conn);

        cmd.Parameters.AddWithValue("@name", tech.Name);
        cmd.Parameters.AddWithValue("@expertise", tech.Expertise);
        cmd.Parameters.AddWithValue("@available", tech.IsAvailable ? 1 : 0);
        cmd.Parameters.AddWithValue("@hours", tech.TotalWorkHours);
        cmd.Parameters.AddWithValue("@email", tech.Email);
        cmd.Parameters.AddWithValue("@phone", tech.PhoneNumber);
        cmd.Parameters.AddWithValue("@hireDate", tech.HireDate.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.Parameters.AddWithValue("@onLeave", tech.IsOnLeave ? 1 : 0);
        cmd.Parameters.AddWithValue("@completed", tech.CompletedRepairs);
        cmd.Parameters.AddWithValue("@shift", tech.Shift);
        cmd.Parameters.AddWithValue("@password", tech.PasswordHash);
        cmd.Parameters.AddWithValue("@id", tech.TechnicianId);

        cmd.ExecuteNonQuery();
    }

    public void DeleteTechnician(int technicianId)
    {
        using var cmd = new SQLiteCommand("DELETE FROM Technicians WHERE TechnicianId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", technicianId);
        cmd.ExecuteNonQuery();
    }

    // Munkalapok kezelése (WorkOrders)

    public List<WorkOrder> GetAllWorkOrders()
    {
        var orders = new List<WorkOrder>();

        using var cmd = new SQLiteCommand("SELECT * FROM WorkOrders", _conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            orders.Add(new WorkOrder
            {
                WorkOrderId = Convert.ToInt32(reader["WorkOrderId"]),
                //RepairId = Convert.ToInt32(reader["RepairId"]),
                CreationDate = DateTime.Parse(reader["CreationDate"].ToString()),
                CompletionDate = string.IsNullOrEmpty(reader["CompletionDate"].ToString())
                                 ? (DateTime?)null
                                 : DateTime.Parse(reader["CompletionDate"].ToString()),
                Status = reader["Status"].ToString(),
                Priority = reader["Priority"].ToString(),
                Notes = reader["Notes"].ToString(),
                HoursWorked = Convert.ToDouble(reader["HoursWorked"]),
                            });
        }
        return orders;
    }

    public WorkOrder GetWorkOrderById(int workOrderId)
    {
        using var cmd = new SQLiteCommand("SELECT * FROM WorkOrders WHERE WorkOrderId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", workOrderId);
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new WorkOrder
            {
                WorkOrderId = Convert.ToInt32(reader["WorkOrderId"]),
                //RepairId = Convert.ToInt32(reader["RepairId"]),
                CreationDate = DateTime.Parse(reader["CreationDate"].ToString()),
                CompletionDate = string.IsNullOrEmpty(reader["CompletionDate"].ToString())
                                 ? (DateTime?)null
                                 : DateTime.Parse(reader["CompletionDate"].ToString()),
                Status = reader["Status"].ToString(),
                Priority = reader["Priority"].ToString(),
                Notes = reader["Notes"].ToString(),
                HoursWorked = Convert.ToDouble(reader["HoursWorked"]),
                            };
        }
        return null;
    }

    public void AddWorkOrder(WorkOrder workOrder)
    {
        using var cmd = new SQLiteCommand(@"
            INSERT INTO WorkOrders ( CreationDate, CompletionDate, Status, Priority, Notes, HoursWorked, RequiresApproval, CreatedBy)
            VALUES ( @creationDate, @completionDate, @status, @priority, @notes, @hoursWorked, @requiresApproval, @createdBy)", _conn);

        //cmd.Parameters.AddWithValue("@repairId", workOrder.RepairId);
        cmd.Parameters.AddWithValue("@creationDate", workOrder.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.Parameters.AddWithValue("@completionDate", workOrder.CompletionDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@status", workOrder.Status);
        cmd.Parameters.AddWithValue("@priority", workOrder.Priority);
        cmd.Parameters.AddWithValue("@notes", workOrder.Notes);
        cmd.Parameters.AddWithValue("@hoursWorked", workOrder.HoursWorked);
       
        cmd.ExecuteNonQuery();
    }

    public void UpdateWorkOrder(WorkOrder workOrder)
    {
        using var cmd = new SQLiteCommand(@"
            UPDATE WorkOrders SET
                
                CreationDate = @creationDate,
                CompletionDate = @completionDate,
                Status = @status,
                Priority = @priority,
                Notes = @notes,
                HoursWorked = @hoursWorked,
                RequiresApproval = @requiresApproval,
                CreatedBy = @createdBy
            WHERE WorkOrderId = @id", _conn);

        //cmd.Parameters.AddWithValue("@repairId", workOrder.RepairId);
        cmd.Parameters.AddWithValue("@creationDate", workOrder.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.Parameters.AddWithValue("@completionDate", workOrder.CompletionDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("@status", workOrder.Status);
        cmd.Parameters.AddWithValue("@priority", workOrder.Priority);
        cmd.Parameters.AddWithValue("@notes", workOrder.Notes);
        cmd.Parameters.AddWithValue("@hoursWorked", workOrder.HoursWorked);
        cmd.Parameters.AddWithValue("@id", workOrder.WorkOrderId);

        cmd.ExecuteNonQuery();
    }

    public void DeleteWorkOrder(int workOrderId)
    {
        using var cmd = new SQLiteCommand("DELETE FROM WorkOrders WHERE WorkOrderId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", workOrderId);
        cmd.ExecuteNonQuery();
    }
}
