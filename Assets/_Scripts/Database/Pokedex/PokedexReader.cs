using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;

public static class PokedexReader
{
   public static List<PokedexEntry> GetPokedexEntries()
   {
      using (var streamReader = new StreamReader("Assets/_Scripts/Database/Pokedex/pokedex.csv"))
      {
         using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
         {
            var records = csvReader.GetRecords<PokedexEntry>().ToList();
            return records;
         }
      }
   }
}