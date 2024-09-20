using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Commands
{
    public record UpdateLoginCommand(Guid EmployeeId, LoginEntity Employee)
        : IRequest<LoginEntity>;
    public class UpdateLoginCommandHandler(ILoginRepository employeeRepository)
        : IRequestHandler<UpdateLoginCommand, LoginEntity>
    {
        public async Task<LoginEntity> Handle(UpdateLoginCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateLoginAsync(request.EmployeeId, request.Employee);
        }
    }
}