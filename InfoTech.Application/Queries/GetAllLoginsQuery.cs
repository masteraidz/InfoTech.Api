using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Queries
{
    public record GetAllLoginsQuery() : IRequest<IEnumerable<LoginEntity>>;
    internal class GetAllLoginsQueryHandler(ILoginRepository loginRepository)
        : IRequestHandler<GetAllLoginsQuery, IEnumerable<LoginEntity>>
    {
        public async Task<IEnumerable<LoginEntity>> Handle(GetAllLoginsQuery request, CancellationToken cancellationToken)
        {
            return await loginRepository.GetLogins();
        }
    }
}
