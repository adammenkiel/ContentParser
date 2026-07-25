
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using CsvHelper;

public class CSVParser : IParser
{
    public ParsedInfo parse(string content)
    {
        try {
            using var reader = new StringReader(content);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            var names = csv.HeaderRecord;

            JsonArray array = [];

            if(names == null)
                throw new Exception();

            while(csv.Read())
            {
                JsonObject line = [];
                foreach(var recordName in names)
                {
                    var RValue = csv.GetField(recordName);
                    line[recordName] = RValue;
                }
                array.Add(line);
            }
            return new ParsedInfo(
                JsonSerializer.SerializeToDocument(array),
                0
            );
        } catch
        {
            throw new ParseException();
        }
    }
}