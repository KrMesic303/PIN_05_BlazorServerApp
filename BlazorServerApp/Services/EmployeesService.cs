using BlazorServerApp.Data;

namespace BlazorServerApp.Services
{
    public class EmployeesService
    {
        //data
        private AppDbContext _context;
        //konstruktor
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        //Methods

        #region Get employees
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var result = _context.Employees;
            return await Task.FromResult(result.ToList());
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }
        #endregion

        #region Add/Update/Delete employees
        public async Task<Employee> AddNewEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(string id)
        {
            Employee findEmployee = _context.Employees.Find(id);
            if (findEmployee == null)
                return null;

            _context.Employees.Remove(findEmployee);
            await _context.SaveChangesAsync();
            return findEmployee;
        }

        public async Task<Employee> UpdateEmployeeAsync(string id, Employee newEmployee)
        {
            Employee findEmployee = _context.Employees.Find(id);
            if (findEmployee == null) 
                return null;

            findEmployee.FullName = newEmployee.FullName;
            findEmployee.Department = newEmployee.Department;
            findEmployee.Salary = newEmployee.Salary;
            await _context.SaveChangesAsync();
            return findEmployee;
        }

        #endregion

    }
}
