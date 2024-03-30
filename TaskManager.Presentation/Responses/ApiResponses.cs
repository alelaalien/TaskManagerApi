namespace TaskManager.Presentation.Responses
{
    public class ApiResponses<T>
    {
        public ApiResponses(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
