namespace AutoService.Shared.Models
{
    public class Repair
    {
        public int IdRepair { get; set; }
        public int EmployeeId { get; set; }
        public int CarId { get; set; }
        public string ContactOwner { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }

        public Repair(int idRepair, int employeeId, int carId, string contactOwner, DateTime dateBegin, DateTime? dateEnd)
        {
            IdRepair = idRepair;
            EmployeeId = employeeId;
            CarId = carId;
            ContactOwner = contactOwner;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
        }

        public Repair() { } 
    }
}
