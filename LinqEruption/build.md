#  <span style="color: white;">Volcano List Project</span>

###### w/ provided List of Volcanos from:

###### https://data.noaa.gov/metaview/page?xml=NOAA/NESDIS/NGDC/MGG/Hazards/iso/xml/G10147.xml&view=getDataView

## <span style="color: white;">Create a console application for querying data using boilerplate data

        dotnet new console (if !dir, dotnet console -o Xxx)

<span style="color: white;">Eruption.cs:</span>

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

<span style="color: white;">Valcano Data Within Program.cs:</span>

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

## <span style="color: white;">Pull data from a data set (eruptions.cs) using LINQ queries</span>

#### ~ Example instance from project ~        
<span style="color: red;">Eruption</span> 
<span style="color: magenta;">EruptionInChile <!-- Mdryboi init -->
    <span style="color: yellow;">=</span>eruptions<!-- Mdryboi -->
    <span style="color: yellow;">. <!-- Ydryboi init -->
        <span style="color: aqua;">First</span>
        ( </span><!-- YDryboi end   -->
    e<!-- Mdryboi -->
    <span style="color: yellow;">=></span>
    e.Location</span> <!-- Mdryboi end -->
<span style="color: yellow;"> ==
    <span style="color: orange;">"Chile"
    )</span>
</span>;

- ##### Object-Find the first eruption that is in Chile and Print the result:
<span style="color: red;">Eruption</span>
- "Eruption" Object

<span style="color: magenta;">EruptionChile</span>
- New Class that preforms query actions

<span style="color: yellow;">=</span> 
<span style="color: magenta;">eruptions
<span style="color: yellow;">.<span style="color: aqua;">First</span>
(</span>e<span style="color: yellow;">=></span> e.Location</span>
<span style="color: yellow;"> == <span style="color: orange;">"Chile"
)</span></span> ;
- Linq Query Statement

</br>
</br>

## <span style="color: white;">Verify correct data is pulled by rendering queried data to the console.</span>]>

-   <span style="color: aqua;">.First</span>

-   <span style="color: aqua;">.FirstOrDefault</span>

-   <span style="color: aqua;">.Where</span>

-   <span style="color: aqua;">.Count</span>

-   <span style="color: aqua;">.OrderBy</span>
-   <span style="color: aqua;">.Select</span>
-   <span style="color: aqua;">.Take(n)</span>

-   <span style="color: aqua;">PrintEach (Custom Function)</span>

</br>
</br>

## <span style="color: white;">Console Output:</span>

    λ dotnet run

1Y. First eruption in Chile:

    Name: Villarrica
    Year: 1963
    Location: Chile
    Elevation: 2847 meters
    Type: Stratovolcano


2Y. Hawaii's 1st eruption:

    Name: Kilauea
    Year: 2018
    Location: Hawaiian Is
    Elevation: 1122 meters
    Type: Shield Volcano


3N. 

    No Greenland volcanoes found.

4Y. 

    First volcanoes after 1900 in New Zealand:
    Name: Taupo
    Year: 1910
    Location: New Zealand
    Elevation: 760 meters
    Type: Caldera


5Y. 

    Volcanoes with elevation over 2000m:
    Name: La Palma
    Year: 2021
    Location: Canary Is
    Elevation: 2426 meters
    Type: Stratovolcano


    Name: Villarrica
    Year: 1963
    Location: Chile
    Elevation: 2847 meters
    Type: Stratovolcano


    Name: Lengai, Ol Doinyo
    Year: 1927
    Location: Tanzania
    Elevation: 2962 meters
    Type: Stratovolcano


    Name: Ceboruco
    Year: 930
    Location: Mexico
    Elevation: 2280 meters
    Type: Stratovolcano


    Name: Etna
    Year: 1329
    Location: Italy
    Elevation: 3320 meters
    Type: Stratovolcano


6A.
    
    Volcanoes with volcano names starting with 'L':
    Name: La Palma
    Year: 2021
    Location: Canary Is
    Elevation: 2426 meters
    Type: Stratovolcano


    Name: Lengai, Ol Doinyo
    Year: 1927
    Location: Tanzania
    Elevation: 2962 meters
    Type: Stratovolcano


6B. 

    Number of volcanoes starting with 'L': 2

7. 

    Highest elevation: 3320 m.

8Y. 

    Volcano with the highest elevation (3320 meters): Etna

9Y. 

    Volcano names in alphabetical order:
    Aira
    Bardarbunga
    Ceboruco
    Chaiten
    Etna
    Hekla
    Katla
    Kilauea
    La Palma
    Lengai, Ol Doinyo
    Santorini
    Taupo
    Villarrica
    
10. 

    Total elevation of all volcanoes combined: 23303 meters

11N. 

        No eruptions found in the year 2000.


12Y. 
    
    Limit 3 stratovolcano eruptions:
    Name: La Palma
    Year: 2021
    Location: Canary Is
    Elevation: 2426 meters
    Type: Stratovolcano


    Name: Villarrica
    Year: 1963
    Location: Chile
    Elevation: 2847 meters
    Type: Stratovolcano


    Name: Hekla
    Year: 1206
    Location: Iceland
    Elevation: 1490 meters
    Type: Stratovolcano



13Y. 

    Eruptions w/ dates prior Year 1000:
    Name: Aira
    Year: 766
    Location: Japan
    Elevation: 1117 meters
    Type: Stratovolcano


    Name: Ceboruco
    Year: 930
    Location: Mexico
    Elevation: 2280 meters
    Type: Stratovolcano


    Name: Katla
    Year: 950
    Location: Iceland
    Elevation: 1490 meters
    Type: Subglacial Volcano


    Name: Santorini
    Year: 46
    Location: Greece
    Elevation: 367 meters
    Type: Shield Volcano


14Y. 
    
    Volcano names of eruptions before Year 1000 (alphabetically):
    Aira
    Ceboruco
    Katla
    Santorini