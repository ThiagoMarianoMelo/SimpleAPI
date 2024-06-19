namespace TestProject.Domain.Command
{
    public class ResponseWithData<T> : Response
    {
        public T? Data { get; set; }
    }
}
