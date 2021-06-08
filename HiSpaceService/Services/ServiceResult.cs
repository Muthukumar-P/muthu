namespace HiSpaceService.Services
{
    public class ServiceResult<T>
    {
        public T Result {get; set;}

        public bool IsSuccess {get; set;}

        public string Message { get; set; }
    }
}