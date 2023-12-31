﻿using MarceloAnimeList.Domain.Command.UserComponents;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserComponents.Request
{
    public class CreateUserRequest : IRequest<CreateUserCommandResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
