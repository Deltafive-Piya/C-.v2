
dotnet new mvc --no-https -o DojoSurveyWithValidations
cd DojoSurveyWithValidations
code .

### <span style= "color: white;">Objectives</span>

-   1) Name, Location, and Favorite Language should all be required.

-   2) Name should be no less than 2 characters.

-   3) Comment isn't required, but if included, should be more than 20 characters.

-   4) If the submission is invalid, render errors.

-   5) If the submission is successful, render the results page.

-   6) Use ViewModel to display results.

### <span style= "color: white;">Pull files from DojoSurveyWithModels</span>

#### Model-User.cs
#### Views-Home-Index.cshtml
#### wwwroot-css-site.css
#### Controllers-HomeController
#### Views-Home-Privacy.cshtml -> Result.cshtml

### <span style= "color: white;">asdasd</span>

</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>


### <span style= "color: white;">notes:</span>
#### Data Anootatations and their purpose
- Required
    - Validates whether field !null
- Regular Expression
    - Validates whether submitted value conforms to a regex
- MinLength()
    - Validates that str/arr field has specified min length
- MaxLength()
    - Validates that str/arr field has specified max length
- Range()
    - Checks whether value is in range
- EmailAddress
    - Validates field is in format[email]
- Compare()
    - Validates two fields are ==
- DataType()
    - Restricts values to a specified DataType