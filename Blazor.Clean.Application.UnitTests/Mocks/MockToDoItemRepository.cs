using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Domain;
using Moq;

namespace Blazor.Clean.Application.UnitTests.Mocks
{
    public class MockToDoItemRepository
    {
        public static Mock<IToDoItemRepository> GetMockToDoItemRepository()
        {
            var toDoItems = new List<ToDoItem>
            {
                new ToDoItem { 
                    Id = 1,
                    Description = "item1",
                    IsCompleted = false
                },
                new ToDoItem {
                    Id = 2,
                   Description = "item2",
                    IsCompleted = true
                },
                new ToDoItem {
                    Id = 3,
                   Description = "item3",
                    IsCompleted = false
                },
            };

            var mockRepo = new Mock<IToDoItemRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(toDoItems);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<ToDoItem>())).Returns((ToDoItem toDoItem) =>
            {
                toDoItems.Add(toDoItem);
                return Task.CompletedTask;
            });
            return mockRepo;
        }
    }
}
