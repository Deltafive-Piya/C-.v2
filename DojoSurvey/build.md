# <span style= "color: white;">Dojo Survey</span>

## <span style= "color: white;"> Design </span>

- Render Pages, styling and ViewBag.
  - Build a Form
  - Create POST request handling the form data.
    - Render data on resultsPage on the POST request
    - Render data on results GET route (holding data throughout redirect)
    - GoBack Btn that redirects to HomePage

## <span style= "color: white;"> Development </span>

- Mkdir project (prject folder not yet created)

        dotnet new web --no-https -o DojoSurvey

#### <span style= "color: white;"> ~Model~ </span>
(delete the useless files...)
- create (folder and) ModelFile

    1) DojoForm.cs

            Class DojoForm:
                Name
                Location
                FavoriteLanguage
                Comment



#### <span style= "color: white;"> ~Controller~ </span>
- create (folder and) modify existing ControllerFile

    1) HomeController.cs

            Class HomeController
                INDEX- Display initial form
                GET-   Results form 
                POST-  Form submission

#### <span style= "color: white;"> ~View(s)~ </span>
- create (folder and) ViewFile

    1) Results.cshtml

    2) Index.cshtml

