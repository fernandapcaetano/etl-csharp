using System;
using etl.Data;

namespace etl.Utils;

public class CsvHelper
{
    public static List<Models> ReadCsv(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var data = new List<Models>();

        foreach (var line in lines.Skip(1)) // Ignorando cabeçalho
        {
            var values = line.Split(',');
            data.Add(new Models
            {
                Field1 = values[0],
                Field2 = values[1]
                // Adicionar outros campos
            });
        }

        return data;
}
}