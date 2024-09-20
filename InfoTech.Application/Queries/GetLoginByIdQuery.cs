using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Queries
{
    public record GetLoginByIdQuery(Guid employeeId) : IRequest<LoginEntity>;

    public class GetLoginByIdQueryHandler(ILoginRepository loginRepository)
        : IRequestHandler<GetLoginByIdQuery, LoginEntity>
    {
        public async Task<LoginEntity> Handle(GetLoginByIdQuery request, CancellationToken cancellationToken)
        {
            return await loginRepository.GetLoginByIdAsync(request.employeeId);
        }
    }
}
