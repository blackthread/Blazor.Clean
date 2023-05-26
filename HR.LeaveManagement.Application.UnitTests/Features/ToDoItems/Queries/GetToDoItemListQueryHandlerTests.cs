using AutoMapper;
using Blazor.Clean.Application.Contracts.Logging;
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems;
using Blazor.Clean.Application.MappingProfiles;
using Blazor.Clean.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Blazor.Clean.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class GetToDoItemListQueryHandlerTests
    {
        private readonly Mock<IToDoItemRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetToDoItemsQueryHandler>> _mockAppLogger;

        public GetToDoItemListQueryHandlerTests()
        {
            _mockRepo = MockToDoItemRepository.GetMockToDoItemRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<LeaveTypeProfile>();
                });
            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetToDoItemsQueryHandler>>();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetToDoItemsQueryHandler( _mapper, _mockRepo.Object, _mockAppLogger.Object);
            var result = await handler.Handle(new GetToDoItemsQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<ToDoItemDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
