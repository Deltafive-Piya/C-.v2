# DateValidator
### <span style="color:yellow;">Objectives</span>
- Create a custom validation.
- Apply your custom validation to a form that will render errors on unsuccessful attempts.
### <span style="color:yellow;">Init</span>
    dotnet new mvc --no-https -o DateValidator
    cd
    code .
### <span style="color:yellow;">Development</span>
- <span style="color:white;">Create Model- User.cs:</span>
    - namespace: our DateValidator
    - using:     DataAnnotations

    - (public) User class (get/set) [required field]
        -   public DateTime for Birthday (get/set) [required field]
        - (to disable the warning for null values:
            #pragma warning disable CS8618
            )

            (protected override) validator checking for future dates
        
- <span style="color:white;">Edit Index.cshtml:</span>
    - Make a Form with the asp-action="process" and "POST" method.
        - Foreach KV Pair (Label+Input+Validation)
        - Input (form submit)

- <span style="color:white;">Edit HomeController.cs and prepare for View-Home-Success(ex-privacy).cshtml:</span>
    - Get
    - Post that redirects to Get "success" (if Model.isValid)
    else returns Index View (with Validations) 
    - Get "success"

- <span style="color:white;">Edit Privacy -> Success.cshtml:</span>
    - Removed Boilerplate
    - add success statement and return btn