namespace TaskManager.Domain.Exceptions
{
    public class BussinessException : Exception
    {
        //implementar en los servicios
        public BussinessException()
        {
            
        }
        public BussinessException(string message) : base(message) { }
       
    }
}
