using MediatR;
using Microsoft.AspNetCore.Http;
using OnionApi.Application.Bases;
using OnionApi.Application.Features.Products.Rules;
using OnionApi.Application.Interfaces.AutoMapper;
using OnionApi.Application.Interfaces.UnitOfWorks;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler,IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly ProductsRules _productsRules;

        public  CreateProductCommandHandler(ProductsRules productsRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _productsRules = productsRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            IList<Product> products=await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await _productsRules.ProductTitleMustNotBeSame(products,request.Title);



            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);
            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIDs)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                    await _unitOfWork.SaveAsync();
                }
            }
            return Unit.Value;
        }
    }
}
