namespace Treinamento.REST.API.Responses
{
    public class GetByIdResponse<T> : BaseResponse
    {
        public T Result { get; set; }
    }
}
