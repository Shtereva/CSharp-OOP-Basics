namespace GrandPrix.Models
{
    public class FailedDriver
    {
        public Driver Driver { get; set; }
        public string Message { get; set; }

        public FailedDriver(Driver driver, string message)
        {
            this.Driver = driver;
            this.Message = message;
        }
    }
}
