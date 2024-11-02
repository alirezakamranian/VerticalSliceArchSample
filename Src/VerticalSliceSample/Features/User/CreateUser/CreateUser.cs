using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VerticalSliceSample.DataBase;

namespace VerticalSliceSample.Features.User.CreateUser
{
    public class CreateUser
    {

        public record CreateUserCommand(string Name, string PhoneNumber) : IRequest<CreateUserResponse>;

        public record CreateUserResponse(string Id);

        public class CreateUserCommandHandler(DataContext context) : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly DataContext _context = context;
            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                _context.Users.Add(new()
                {
                    Name = request.Name,
                    Phone = request.PhoneNumber
                });

                await _context.SaveChangesAsync(cancellationToken);

                var createdUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Phone.Equals(
                        request.PhoneNumber), cancellationToken);

                return new CreateUserResponse(createdUser.ID.ToString());
            }
        }

        public record CreateUserRequest()
        {
            [Required]
            public string Name { get; set; }
            [Required]
            [Phone]
            public string PhoneNumber { get; set; }
        };

        public class LoginUserEndpoint : ICarterModule
        {
            public void AddRoutes(IEndpointRouteBuilder app)
            {
                app.MapPost("/user", async ([FromBody] CreateUserRequest request, IMediator mediator, CancellationToken cancellationToken) =>
                {
                    var command = new CreateUserCommand(
                        request.Name, request.PhoneNumber);

                    var response = await mediator
                        .Send(command, cancellationToken);

                    return response;
                }).WithName("CreateUser").WithOpenApi();
            }
        }
    }
}
