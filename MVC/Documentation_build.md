## MVC Example
<span style="color: orange;">Create:</span>
Using dotnet new web --no-https -o Xxx

       dotnet new web --no-https -o MVC
       cd Xxx
       code .

-   Upon creation and running new project, a popup may appear:

    YES to "Required assets to build and debug are missing from 'Xxx'. Add them?"

<span style="color: orange;">Alter Boilerplate:</span>
Within Program.cs, replace autogen'd 
"app.MapGet("/", () => "Hello World!");" with:

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

-   The Name of the controller must follow guidelines to pair with the inner workings of C++++:

    -   XxxController.cs (within the new Controllers Folder)

