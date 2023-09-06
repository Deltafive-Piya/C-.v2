## Create a console application for querying data using the data provided.

        dotnet new console (if !dir, dotnet console -o Xxx)

Eruption.cs:

        public class Eruption
    {
        public string Volcano { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
        public int ElevationInMeters { get; set; }
        public string Type { get; set; }
        public Eruption(string volcano, int year, string location, int elevationInMeters, string type)
        {
            Volcano = volcano;
            Year = year;
            Location = location;
            ElevationInMeters = elevationInMeters;
            Type = type;
        }
        
        // This method overrides the original ToString method built into C#
        // So we can get a specialized response!
        public override string ToString()
        {
            return $@"
                Name: {Volcano}
                Year: {Year}
                Location: {Location}
                Elevation: {ElevationInMeters} meters
                Type: {Type}
                ";
        }
    }

Filler Data Within Program.cs:

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
</br>
</br>

## Pull data from a data set (eruptions.cs) using LINQ queries.

#####  <span style="color: grey;">Object-Find the first eruption that is in Chile and Print the result:</span>
        
<span style="color: red;">Eruption</span> 
<span style="color: magenta;">EruptionInChile <!-- Mdryboi init -->
<span style="color: yellow;">=</span> 
eruptions<!-- Mdryboi -->
<span style="color: yellow;">. <!-- Ydryboi init -->
<span style="color: aqua;">First</span>
(</span><!-- YDryboi end   -->
e<!-- Mdryboi -->
<span style="color: yellow;">=></span>
 e.Location</span> <!-- Mdryboi end -->
<span style="color: yellow;"> ==
<span style="color: orange;">"Chile"
)</span>;

Eruption (red)- "Eruption" Object

EruptionChile(purple)- The name of our new class that does actions

<span style="color: yellow;">=</span> 
eruptions<!-- Mdryboi -->
<span style="color: yellow;">. <!-- Ydryboi init -->
<span style="color: aqua;">First</span>
(</span><!-- YDryboi end   -->
e<!-- Mdryboi -->
<span style="color: yellow;">=></span>
 e.Location</span> <!-- Mdryboi end -->
<span style="color: yellow;"> ==
<span style="color: orange;">"Chile"
)</span>;-</span> Linq Powers

</br>
</br>

## Verify correct data is pulled by rendering queried data to the console.

-   <span style="color: aqua;">.First</span>

-   <span style="color: aqua;">.FirstOrDefault</span>

-   <span style="color: aqua;">.Where</span>

-   <span style="color: aqua;">.Count</span>

-   <span style="color: aqua;">.OrderBy</span>
-   <span style="color: aqua;">.Select</span>
-   <span style="color: aqua;">.Take(n)</span>

-   <span style="color: aqua;">PrintEach (Custom Function)</span>