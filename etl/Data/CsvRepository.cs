using System;

namespace etl.Data;

public class CsvRepository
{
    private readonly MyDbContext _context;

    public CsvRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task SaveCsvData(List<Models> data)
    {
        _context.Models.AddRange(data);
        await _context.SaveChangesAsync();
    }
}
