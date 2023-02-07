using System.Globalization;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.TodoLists.Queries.ExportTodos;
using OnlineApplicationSystem.Infrastructure.Files.Maps;
using CsvHelper;

namespace OnlineApplicationSystem.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
