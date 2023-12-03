using MarceloAnimeList.Service.Command.UserAnimeComponents.Request.UpdateUserAnime;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Handler
{
    public class UpdateUserAnimeHandler : IRequestHandler<UpdateUserAnimeRequest, object>
    {
        public Task<object> Handle(UpdateUserAnimeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
