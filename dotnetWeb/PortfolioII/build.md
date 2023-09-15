# <span style= "color: white;">Portfolio</span>
- The Portfolio II project will contain "About me" (root), "My Projects", and "Contact Me" pages, connected by links.
- A Navbar will also be implimented

### <span style= "color: white;">objectives</span>

- Rebuild PortfolioII with views instead of returning print statements

### <span style= "color: white;">steps</span>

#### <span style= "color: white;">Update your 3 routes to return Views instead of strings:</span>

- Make 3 files within Hello Folder within Views Folder:

1) Index.cshtml:

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

2) Projects.cshtml:

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

    -   Patch within HelloController:

        public <span style="color:red; text-decoration: line-through;">string</span> Projects()
        
        return <span style="color:red; text-decoration: line-through;">"These are my projects"</span>

        public <span style="color:green">ViewResult</span> Projects()
        
        return <span style="color:green">View("Projects")</span>

3) Contact.cshtml:

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

    -   Patch within HelloController:

        public <span style="color:red; text-decoration: line-through;">string</span> Contact()
        
        return <span style="color:red; text-decoration: line-through;">"Contact Me"</span>

        public <span style="color:green">ViewResult</span> Contact()
        
        return <span style="color:green">View("Contact")</span>

#### <span style= "color: white;">Add a navbar with links to each page at the top:</span>

#### <span style= "color: white;">The Home page should have a picture, name, and about me section:</span>

#### <span style= "color: white;">The Projects page should have at least 3 projects, each with a title, image, and small description:</span>

#### <span style= "color: white;">The Contact page should have a form requesting the user's name, email, and a message (this form does not need to function):</span>

#### <span style= "color: white;">Add CSS styling:</span>

#### <span style= "color: white;">Bonus: Add some JavaScript for a more interactive user experience:</span>




