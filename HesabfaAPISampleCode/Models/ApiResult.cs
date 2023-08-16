namespace HesabfaAPISampleCode.Models
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}
