using OnlineApplicationSystem.Application.TodoLists.Queries.ExportTodos;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
