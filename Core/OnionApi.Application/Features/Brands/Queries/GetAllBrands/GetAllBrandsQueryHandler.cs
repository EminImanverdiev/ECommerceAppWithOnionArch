using MediatR;
using Microsoft.AspNetCore.Http;
using OnionApi.Application.Bases;
using OnionApi.Application.Interfaces.AutoMapper;
using OnionApi.Application.Interfaces.UnitOfWorks;
using OnionApi.Domain.Entities;

namespace OnionApi.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : BaseHandler, IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
    {
        public GetAllBrandsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.GetReadRepository<Brand>().GetAllAsync();
            return _mapper.Map<GetAllBrandsQueryResponse, Brand>(brands);
        }
    }
}
