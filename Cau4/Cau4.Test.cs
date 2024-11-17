namespace Cau4
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Employee(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
    public class EmployeeService
    {
        private List<Employee> _employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void UpdateEmployee(int id, string firstName, string lastName, string email)
        {
            Employee employee = _employees.Find(e => e.Id == id);
            if (employee != null)
            {
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Email = email;
            }
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _employees.Find(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }
    }
    [TestFixture]
    public class Test
    {
        private EmployeeService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new EmployeeService();
        }

        [Test]
        public void Add()
        {
            Employee e = new Employee(1, "Dũng", "Nam", "dungdz@gmail.com");
            _service.AddEmployee(e);
            Assert.AreEqual(1, _service.GetAll().Count);
        }

        [Test]
        public void Edit()
        {
            Employee e = new Employee(1, "Dũng", "Nam", "dungdz@gmail.com");
            _service.AddEmployee(e);
            _service.UpdateEmployee(1, "Dung", "Trang", "dungpro@gmail.com");

            Employee updateItem = _service.GetAll().Find(e => e.Id == 1);
            Assert.AreEqual("Dung", updateItem.FirstName);
            Assert.AreEqual("Trang", updateItem.LastName);
            Assert.AreEqual("dungpro@gmail.com", updateItem.Email);
        }

        [Test]
        public void Delete()
        {
            Employee e = new Employee(1, "Dũng", "Nam", "dungdz@gmail.com");
            _service.AddEmployee(e);
            _service.DeleteEmployee(1);
            Assert.AreEqual(0, _service.GetAll().Count);
        }
    }

}