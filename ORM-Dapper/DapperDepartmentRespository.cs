using System.Data;
using Dapper;


namespace ORM_Dapper;

public class DapperDepartmentRespository : IDepartmentRepository 
{
    private readonly IDbConnection _conn;

    public DapperDepartmentRespository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _conn.Query<Department>("SELECT * FROM Departments");
    }
    
    public void InsertDepartment(string name)
    
    {
        _conn.Execute("Insert Into departments (Name) Values (@name)", new { name });
    }
}