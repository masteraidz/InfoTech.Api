using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Commands
{
    public record DeleteUserCommand(Guid UserId) : IRequest<bool>;

    internal class DeleteUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.DeleteUserAsync(request.UserId);
        }
    }
}
