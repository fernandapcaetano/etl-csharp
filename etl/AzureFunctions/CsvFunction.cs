using System;

namespace etl.AzureFunctions;

public class CsvFunction
{
    [FunctionName("CsvFunction")]
    public static async Task Run(
        [TimerTrigger("*/5 * * * *")] TimerInfo myTimer, 
        ILogger log,
        [Inject] CsvService csvService)
    {
        string folderPath = @"C:\path\to\csv\folder";
        var files = Directory.GetFiles(folderPath, "*.csv");

        foreach (var file in files)
        {
            await csvService.ProcessCsv(file);
            log.LogInformation($"Processed file: {file}");
        }
    }
}
