namespace EducaMais.Application.Dtos
{
    public record class Response<T>
    {
        public Response(bool status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public bool Status { get; init; }
        public string Message { get; init; }
        public T? Data { get; init; }
    }
}
