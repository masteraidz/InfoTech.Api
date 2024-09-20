using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Commands
{
    public record AddUserCommand(UserEntity Login) : IRequest<UserEntity>;
    public class AddUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.AddUserAsync(request.Login);
        }
    }
}
