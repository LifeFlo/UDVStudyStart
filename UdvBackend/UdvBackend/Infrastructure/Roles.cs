namespace UdvBackend;

public class Roles
{
    public static HRRole HR { get; private set; } = new();

    public static EmployeeRole Employee { get; private set; } = new();

    public static void CreateEmployeeRoleSingleton(Guid id)
    {
        if (Employee.Id == Guid.Empty) return;
        
        Employee = new EmployeeRole(id);
    }
    
    public static void CreateHRRoleSingleton(Guid id)
    {
        if (HR.Id == Guid.Empty) return;
        
        HR = new HRRole(id);   
    }

    public class EmployeeRole
    {
        public readonly Guid Id = Guid.Empty;
        public readonly string NameRole = "Employee";

        public EmployeeRole()
        {}
        
        public EmployeeRole(Guid id)
        {
            Id = id;
        }
    }

    public class HRRole
    {
        public readonly Guid Id = Guid.Empty;
        public readonly string NameRole = "HR";

        public HRRole()
        { }
        public HRRole(Guid id)
        {
            Id = id;
        }
    }
}