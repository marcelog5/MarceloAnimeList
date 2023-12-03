using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Query;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Service.Service;
using Moq;

namespace MarceloAnimeList.Test.Domain.UserAnimeTest.Service
{
    public class UserAnimeServiceTest
    {
        [Fact]
        public async void GetMustReturnAllUserAnimes()
        {
            // Arrange
            var userAnimeRepoMock = new Mock<IUserAnimeRepository>();
            var userAnimeResponse = new List<UserAnime>()
            {
                new UserAnime()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    AnimeId = Guid.NewGuid(),
                    Active = true,
                    Anime = new Anime()
                    {
                        Title = "Test",
                    }
                }
            };

            userAnimeRepoMock
                .Setup(repo => repo.GetAsync(It.IsAny<Func<IQueryable<UserAnime>, IQueryable<UserAnime>>>(), new CancellationToken()))
                .ReturnsAsync(userAnimeResponse);

            var mapperMock = new Mock<IMapper>();

            var userAnimeResponses = new List<UserAnimeResponse>
            {
                new UserAnimeResponse()
                {
                    Title= "Test",
                }
            };

            mapperMock
                .Setup(mapper => mapper.Map<List<UserAnimeResponse>>(It.IsAny<List<UserAnime>>()))
                .Returns(userAnimeResponses);

            GetUserAnimeQuery query = new GetUserAnimeQuery();

            
            UserAnimeService userAnimeService = new UserAnimeService(
                null,
                userAnimeRepoMock.Object,
                null,
                mapperMock.Object,
                null
            );

            // Act
            var userAnimes = await userAnimeService.Get(query);
            
            // Assert
            Assert.NotNull(userAnimes);
            Assert.Equal("Test", userAnimes.Result.UserAnimes.FirstOrDefault().Title);
        }
    }
}
