using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnionApi.Application.Bases;
using OnionApi.Application.Interfaces.AutoMapper;
using OnionApi.Application.Interfaces.UnitOfWorks;
using OnionApi.Domain.Entities;

namespace OnionApi.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : BaseHandler,IRequestHandler<CreateBrandCommandRequest,Unit>
    {
        public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("az");
            List<Brand> brands = new();
            for (int i = 0; i < 1000000; i++)
            {
                brands.Add(new(faker.Commerce.Department(1)));
            }
            await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }

}
