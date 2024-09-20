﻿using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Commands
{
    public record UpdateUserCommand(Guid UserId, UserEntity User)
        : IRequest<UserEntity>;
    public class UpdateUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<UpdateUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.UpdateUserAsync(request.UserId, request.User);
        }
    }
}