using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Commands
{
    public record AddLoginCommand(LoginEntity Login) : IRequest<LoginEntity>;
    public class AddLoginCommandHandler(ILoginRepository loginRepository) : IRequestHandler<AddLoginCommand, LoginEntity>
    {
        public async Task<LoginEntity> Handle(AddLoginCommand request, CancellationToken cancellationToken)
        {
            return await loginRepository.AddLoginAsync(request.Login);
        }
    }
}
