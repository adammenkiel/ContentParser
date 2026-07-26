
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using CsvHelper;

public class CSVParser : IParser
{
    public ParsedInfo Parse(string content)
    {
        try {
            using var reader = new StringReader(content);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            var names = csv.HeaderRecord;

            JsonArray array = [];
            int Count = 0;

            if(names == null)
                throw new Exception("Header records are null!");

            while(csv.Read())
            {
                JsonObject line = [];
                foreach(var recordName in names)
                {
                    var RValue = csv.GetField(recordName);
                    line[recordName] = RValue;
                }
                array.Add(line);
                Count++;
            }
            return new ParsedInfo(
                JsonSerializer.SerializeToDocument(array),
                Count
            );
        } catch (Exception exception)
        {
            throw new ParseException(exception.Message, exception);
        }
    }
}