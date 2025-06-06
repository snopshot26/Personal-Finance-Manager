using Microsoft.EntityFrameworkCore;
using Personal_Finance_Manager.Models;
using Personal_Finance_Manager.Service;
using Personal_Finance_Manager.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace Personal_Finance_Manager.Tests.Service
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterAndAuthenticate_ReturnsUser()
        {
            var options = new DbContextOptionsBuilder<FinanceContext>()
                .UseInMemoryDatabase("UserTest")
                .Options;

            using var context = new FinanceContext(options);
            var service = new UserService(context);

            var user = await service.RegisterAsync("alice", "secret");
            Assert.NotNull(user);

            var auth = await service.AuthenticateAsync("alice", "secret");
            Assert.NotNull(auth);
            Assert.Equal(user.Id, auth!.Id);
        }

        [Fact]
        public async Task Register_Duplicate_ThrowsException()
        {
            var options = new DbContextOptionsBuilder<FinanceContext>()
                .UseInMemoryDatabase("DuplicateTest")
                .Options;

            using var context = new FinanceContext(options);
            var service = new UserService(context);

            await service.RegisterAsync("bob", "pass");

            await Assert.ThrowsAsync<UserAlreadyExistsException>(async () =>
            {
                await service.RegisterAsync("bob", "pass");
            });
        }
    }
}
