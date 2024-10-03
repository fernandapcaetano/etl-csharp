using System;
using etl.Data;
using etl.Utils;

namespace etl.Services;

public class CsvService
{
    private readonly CsvRepository _repository;

    public CsvService(CsvRepository repository)
    {
        _repository = repository;
    }

    public async Task ProcessCsv(string filePath)
    {
        var data = CsvHelper.ReadCsv(filePath);
        await _repository.SaveCsvData(data);
    }
}
