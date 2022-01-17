# blog-backend
The backend project for this blog
Add migration  : dotnet ef --startup-project Blog.API/Blog.API.csproj migrations add <Name> -p Blog.Data/Blog.Data.csproj
Update Database : dotnet ef --startup-project Blog.API/Blog.API.csproj database update
