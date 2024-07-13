using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionApi.Application.DTOs;
using OnionApi.Application.Interfaces.AutoMapper;
using OnionApi.Application.Interfaces.UnitOfWorks;
using OnionApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnionApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>()
                .GetAllAsync(include: x => x.Include(b => b.Brand));

            var mappedProducts = _mapper.Map<IList<GetAllProductsQueryResponse>, IList<Product>>(products);

            foreach (var item in mappedProducts)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }
            throw new Exception("hata messahi");
            //return mappedProducts;
        }
    }
}
