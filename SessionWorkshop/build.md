# <span style= "color: white;">SessionWorkShop</span>

## <span style= "color: yellow;">Objectives</span>
- Create session instances to persist until session is cleared.
- Apply logical thinking skills to perform mathematical operations on a session value.
- Implement best practices to clear session for a user.
## <span style= "color: yellow;">Deliverables</span>
1) User can input their name and have it be remembered by session
2) Establish a starting value
3) Create functionality for +1, -1, x2 and +random
4) Implement logout feature
5) <span style= "text-decoration: line-through;"> Bonus: Add security to prevent a user from accessing the dashboard without inputting a name
6)  <span style= "text-decoration: line-through;">Challenge: Rework logic to only use one route for mathematical operations</span>

### <span style= "color: yellow;">Init</span>
    dotnet new mvc --no-https -o SessionWorkshop
    cd SessionWorkshop
    code .