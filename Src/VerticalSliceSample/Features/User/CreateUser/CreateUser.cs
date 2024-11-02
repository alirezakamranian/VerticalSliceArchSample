using MediatR;
using VerticalSliceSample.Abstractions;
using VerticalSliceSample.DataBase;

namespace VerticalSliceSample.Features.User.CreateUser
{
    public class CreateUser(DataContext context)
    {
        private readonly DataContext _context = context;


        public record CreateUserCommand : IRequest<CreateUserResponse>
        {
            public string? Name { get; set; } 
        };

        public record CreateUserResponse()
        {
            public string? Id { get; set; }
        };

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            public Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        public class LoginUserEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {

            }
        }
    }
}
