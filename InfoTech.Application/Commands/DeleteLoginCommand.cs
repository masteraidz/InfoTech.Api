using InfoTech.Core.Interfaces;
using MediatR;

namespace InfoTech.Application.Commands
{
    public record DeleteLoginCommand(Guid EmployeeId) : IRequest<bool>;

    internal class DeleteEmployeeCommandHandler(ILoginRepository employeeRepository)
        : IRequestHandler<DeleteLoginCommand, bool>
    {
        public async Task<bool> Handle(DeleteLoginCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteLoginAsync(request.EmployeeId);
        }
    }
}
