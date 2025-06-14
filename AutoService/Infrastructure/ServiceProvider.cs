namespace AutoService.Infrastructure
{
    public class ServiceProvider
    {
        public AuthApiClient AuthApiClient { get; }
        public UserManagementApiClient UserManagementApiClient { get; }
        public CarApiClient CarApiClient { get; }
        public EmployeeApiClient EmployeeApiClient { get; }
        public RepairApiClient RepairApiClient { get; }
        public AssemblyApiClient AssemblyApiClient { get; }
        public RepairInfoApiClient RepairInfoApiClient { get; }
        public StatisticsApiClient StatisticsApiClient { get; }

        public ServiceProvider()
        {
            AuthApiClient = new AuthApiClient();
            UserManagementApiClient = new UserManagementApiClient();
            CarApiClient = new CarApiClient();
            EmployeeApiClient = new EmployeeApiClient();
            RepairApiClient = new RepairApiClient();
            AssemblyApiClient = new AssemblyApiClient();
            RepairInfoApiClient = new RepairInfoApiClient();
            StatisticsApiClient = new StatisticsApiClient();
        }
    }
}
