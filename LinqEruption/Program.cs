List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};


// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");


// Execute Assignment LINQ Tasks here!

//1. find the first eruption that is in Chile and print the result.
Eruption EruptionInChile = eruptions.First(e => e.Location == "Chile");

if (EruptionInChile != null)
    Console.WriteLine($"\n1Y. First eruption in Chile:\n{EruptionInChile}");
else Console.WriteLine("\n1N. No Chilean volacanoes found.");


//2. Find the first eruption from the "Hawaiian Is" location and print it. If !exists, print "No Hawaiian Is Eruption found."
Eruption EruptionInHawaiianIs = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");

if (EruptionInHawaiianIs != null)
    Console.WriteLine($"\n2Y. Hawaii's 1st eruption:\n{EruptionInHawaiianIs}");
else Console.WriteLine("\n2N. No Hawaiian Is valvanoes found.");


//3. Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Eruption EruptionInGreenland = eruptions.FirstOrDefault(e => e.Location == "Greenland");

if (EruptionInGreenland != null)
    Console.WriteLine($"\n3Y. First eruption in Greenland:\n{EruptionInGreenland}");
else Console.WriteLine("\n3N. No Greenland volcanoes found.");


//4. Find the first eruption that is after the year 1900 AND in "New Zealand", then print it. //Objects
Eruption EruptionInNewZealandAfter1900 = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");

if (EruptionInNewZealandAfter1900 != null)
    Console.WriteLine($"\n4Y. First volcanoes after 1900 in New Zealand:\n{EruptionInNewZealandAfter1900}");
else Console.WriteLine("\n4N. No volcanoes found in New Zealand after 1900.");

//5. Find all eruptions where the volcano's elevation is over 2000m and print them. //Objects
IEnumerable<Eruption> HighElevationEruptions = eruptions.Where(e => e.ElevationInMeters > 2000);

if (HighElevationEruptions != null)
    PrintEach(HighElevationEruptions, "5Y. Volcanoes with elevation over 2000m:");
else Console.WriteLine("5N. No volcanoes >2000 m. available to examine.");
//6. Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found. //Objects
IEnumerable<Eruption> EruptionsStartingWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));

PrintEach(EruptionsStartingWithL, "6A. Volcanoes with volcano names starting with 'L':");

// Print EruptionsFound.Count(). //Int
int eruptionsStartingWithL = EruptionsStartingWithL.Count();

Console.WriteLine($"\n6B. Number of volcanoes starting with 'L': {eruptionsStartingWithL}");

//7. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!) //Int
int HighestElevation = eruptions.Max(e => e.ElevationInMeters);

Console.WriteLine($"\n7. Highest elevation: {HighestElevation} m.");

//8. Use the highest elevation variable to find and print the name of the Volcano with that elevation. //String
Eruption HighestVolcano = eruptions.FirstOrDefault(e => e.ElevationInMeters == HighestElevation);

if (HighestVolcano != null)
    Console.WriteLine($"\n8Y. Volcano with the highest elevation ({HighestElevation} meters): {HighestVolcano.Volcano}");
else Console.WriteLine("\n8N. No volcanoes available to examine.");

//9. Print all Volcano names alphabetically. //String
IEnumerable<string> VolcanoNamesAlphabetically = eruptions.Select(e => e.Volcano).OrderBy(name => name);

if (VolcanoNamesAlphabetically != null) {
    Console.WriteLine("\n9Y. Volcano names in alphabetical order:");
    foreach (string volcanoName in VolcanoNamesAlphabetically)
        Console.WriteLine(volcanoName);
}
else Console.WriteLine("\n9N. No volcanoes available to provide.");

//10. Print the sum of all the elevations of the volcanoes combined. //Int
int SumOfAllElevations = eruptions.Sum(e => e.ElevationInMeters);

Console.WriteLine($"\n10. Total elevation of all volcanoes combined: {SumOfAllElevations} meters");

//11. Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query) Boolean Statment
bool EruptionsInYear2000Exist = eruptions.Any(e => e.Year == 2000);

if (EruptionsInYear2000Exist)
    Console.WriteLine("\n11Y. There were eruptions in the year 2000.");
else Console.WriteLine("\n11N. No eruptions found in the year 2000.");

//12. Find all stratovolcanoes and print just the first three (Hint: look up Take) //Objects
IEnumerable<Eruption> Stratovolcanoes = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);

if (Stratovolcanoes.Count() > 2)
    PrintEach(Stratovolcanoes, "\n12Y. Limit 3 stratovolcano eruptions:");
else Console.WriteLine("\n12N. Not enough stratovolcano to perform comparison.");

//13. Print all the eruptions that happened 1000 CE (alphabetically by name). //Object[key]
IEnumerable<Eruption> EruptionsBefore1000CE = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);

if (HighestVolcano != null)
    PrintEach(EruptionsBefore1000CE, "\n13Y. Eruptions w/ dates prior Year 1000:");
else Console.WriteLine("\n13N. No eruptions found prior to Year 1000.");

//14. Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed. //String[i]
IEnumerable<string> VolcanoNamesBefore1000CE = eruptions
    .Where(e => e.Year < 1000)
    .OrderBy(e => e.Volcano)
    .Select(e => e.Volcano);

if (VolcanoNamesBefore1000CE.Any()) {
    Console.WriteLine("\n14Y. Volcano names of eruptions before Year 1000 (alphabetically):");
    foreach (string volcano in VolcanoNamesBefore1000CE)
    {
        Console.WriteLine(volcano);
    }
}
else Console.WriteLine("\n14N. No eruptions found prior to Year 1000.");

// HELPER
// Method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);


    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
