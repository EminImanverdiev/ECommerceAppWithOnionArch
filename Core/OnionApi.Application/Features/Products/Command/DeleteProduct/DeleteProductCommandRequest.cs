using MediatR;

namespace OnionApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
