namespace CelilCavus.Departman.Entity.Entity
{
    public  class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNo { get; set; }
        public string Salary { get; set; }
        public int DepartmanId { get; set; }
        public Department Departman { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
