Some sections may not make sense in Github as they are not conditionally colored, in comparison to the view within VSCode.
# <span style= "color: white;">Portfolio II</span>
- The Portfolio II project will contain "About me" (root), "My Projects", and "Contact Me" pages, connected by links.
- A Navbar will also be implimented

## <span style= "color: yellow;">objective</span>

- Rebuild Portfolio I with views instead of returning print statements (Portfolio I)

## <span style= "color: yellow;">steps</span>

### <span style= "color: white;">Update your 3 routes to return Views instead of strings:</span>

- Make 3 files within Hello Folder within Views Folder:

1) <span style= "color: white;">Index.cshtml:</span>

        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE-edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Piya About Me template</title>
        </head>
        <body>
            <h1>About Me!</h1>
        </body>
        </html>
    -   Patch within HelloController so the controller contacts the newly created Views instead of returning a string statement:

        public <span style="color:red; text-decoration: line-through;">string</span> Index()
        
        return <span style="color:red; text-decoration: line-through;">"This is my index"</span>

        public <span style="color:green">ViewResult</span> Index()
        
        return <span style="color:green">View("Index")</span>

2) <span style= "color: white;">Projects.cshtml:</span>

        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE-edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Piya About Me template</title>
        </head>
        <body>
            <h1>My Projects</h1>
        </body>
        </html>

    -   <span style= "color: white;">Patch within HelloController:</span>

        public <span style="color:red; text-decoration: line-through;">string</span> Projects()
        
        return <span style="color:red; text-decoration: line-through;">"These are my projects"</span>

        public <span style="color:green">ViewResult</span> Projects()
        
        return <span style="color:green">View("Projects")</span>

3) <span style= "color: white;">Contact.cshtml:</span>

        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE-edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Piya Contact Me template</title>
        </head>
        <body>
            <h1>Contact Me!</h1>
        </body>
        </html>

    -   <span style= "color: white;">Touch HelloController:</span>

        public <span style="color:red; text-decoration: line-through;">string</span> Contact()
        
        return <span style="color:red; text-decoration: line-through;">"Contact Me"</span>

        public <span style="color:green">ViewResult</span> Contact()
        
        return <span style="color:green">View("Contact")</span>

### <span style= "color: white;"> CHECK- HelloController should now look like this:</span>

        using Microsoft.AspNetCore.Mvc;
        namespace PortfolioII.Controllers;

        public class HelloController : Controller
        {
            [HttpGet ("")]
            public ViewResult Index()
            {
                return View("Index");
            }

            [HttpGet ("projects")]
            public ViewResult Projects()
            {
                return View("Projects");
            }

            [HttpGet ("contact")]
            public ViewResult Contact()
            {
                return View("Contact");
            }

        } 

### <span style= "color: yellow;">Prep CSS styling:</span>

- Apply link:css (within head tag) to new viewFiles :

        <link rel="stylesheet" href="~/css/style.css">

- Create the wwwroot Folder containing the css Folder

### <span style= "color: yellow;">Add a navbar with links to each page at the top:</span>

- Patch the viewFile with a NavBar:

        @* Index.cshtml *@
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE-edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Piya About Me template</title>
            <link rel="stylesheet" href="~/css/style.css">
        </head>
        <body>
            <div class="navbar">
                <a href="/">Home</a>            @*Link to RootPage; labled "Home"*@
                <span> | </span>                @*spacer*@
                <a href="/projects">Projects</a>@*Link to Projects; labled "Projects"*@
                <span> | </span>                @*spacer*@
                <a href="/contact">Contact</a>  @*Link to ContactPage; labled "Contact"*@
                <span> | </span>                @*spacer*@
            </div>
            <h1>About Me!</h1>
        </body>
        </html>

### <span style= "color: yellow;">Add CSS styling:</span>

        /* NAVBAR cssness */
        * {
            font-family: monospace;
        }

        .navbar {
            display: flex;
            justify-content: space-evenly;
            background-color: #333; /* Background color of the navbar */
            color: white; /* Text color for links and separators */
            padding: 10px; /* Add some padding for better spacing */
            border-radius: 4px;
        }

        .navbar a {
            text-decoration: none; /* Remove underlines from links */
            color: navajowhite; /* Text color for links */
            margin: 0 10px; /* Add margin to separate links */
        }

        .navbar a:hover {
            text-decoration: underline; /* Add underline on hover */
        }

        /* Heading styles */
        h1 {
            font-size: 24px; /* Adjust the font size as needed */
            margin-top: 20px; /* Add space above the heading */
            text-align: center; /* Center the heading text */
        }

        .navbar span {
            box-shadow: 0 0 3px navajowhite; /* Sidewalk solar lights */
        }

### <span style= "color: yellow;">Impliment- Home Page: picture, name, about me section:</span>
<span style= "color: white;">Allow for storage of media; within Images Folder within wwwroot Folder:</span>
-       mkdir images
    - within that images Folder, populate with media

#### <span style= "color: white;">Index.cshtml & Style.css (Picture, Name About Me Section):</span>

1) <span style= "color: white;">Touch Index.cshtml:</span>

        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE-edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Piya- About Me Page</title>
            <link rel="stylesheet" href="~/css/style.css">
        </head>
        <body>
            <div class="navbar">
                <span> | </span> 
                <a href="/">Home</a>            @*Link to RootPage; labled "Home"*@
                <span> | </span>                @*spacer*@
                <a href="/projects">Projects</a>@*Link to Projects; labled "Projects"*@
                <span> | </span>                @*spacer*@
                <a href="/contact">Contact</a>  @*Link to ContactPage; labled "Contact"*@
                <span> | </span>                @*spacer*@
            </div>
            <div class="content">
                <h1 class="center">About Me</h1>
                <div class="container">
                    <div class="left">
                        <img class="size-compress-two-hundred" src="/images/pfp.jpg">
                        <h4>Pier Stoddard</h4>
                        <h4>I love RoR :)</h4>
                    </div>
                    <div class="right">description baby! Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptate necessitatibus nobis, odio a facere enim molestiae voluptatem cupiditate porro, tenetur ad soluta, maxime doloremque perspiciatis reiciendis. Autem obcaecati alias cupiditate?</div>
                </div>
            </div>
        </body>
        </html>

2) <span style= "color: white;">Touch Style.css: Navbar and Index Page styling</span>

        * {
        font-family: monospace;
        }

        .navbar {
            display: flex;
            justify-content: space-evenly;
            background-color: #333; /* Background color of the navbar */
            color: white; /* Text color for links and separators */
            padding: 10px; /* Add some padding for better spacing */
            border-radius: 4px;
        }

        .navbar a {
            text-decoration: none; /* Remove underlines from links */
            color: navajowhite; /* Text color for links */
            margin: 0 10px; /* Add margin to separate links */
        }

        .navbar a:hover {
            text-decoration: underline; /* Add underline on hover */
        }

        /* update index styling --------------------*/

        h1 {
        font-size: 24px;
        margin-top: 20px;
        text-align: center;
        }

        .navbar span {
            box-shadow: 0 0 3px navajowhite; /* Sidewalk solar lights */
        }

        .content {
            text-align: center;
            margin: 20px;
        }

        .center {
            text-align: center;
        }

        .container {
            display: flex;
            justify-content: space-between; 
            align-items: center; 
            margin-top: 20px;
        }

        /* Left content styles */
        .left {
            flex: 1; /* 1 power */
            text-align: left;
        }

        /* Right content styles */
        .right {
            flex: 1; /* 1 power */
        /*background color 2.0*/
            background: linear-gradient(to bottom, rgb(255, 248, 237), transparent);
            border-radius: 3px;
            border-bottom: solid 2px #333;
        }

        /* Image prettified down to 200px */
        .size-compress-two-hundred {
            border-radius: 4px;/* Prettify */
            max-width: 200px; /* Compression- 200px */
            height: auto; /* AspectRatioKeeper */
        }


### <span style= "color: yellow;">Impliment- Projects Page: <=3 projects, foreach{ title, image, small description }</span>

### <span style= "color: yellow;">Impliment- Contact Page: form ( requesting user's name, email, message)</span>

### <span style= "color: yellow;">Bonus: Add some JavaScript for a more interactive user experience</span>




