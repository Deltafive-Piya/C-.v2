# <span style= "color: white;">First Connection- new mvc</span>

## <span style= "color: yellow;">Objective</span>
- <span style= "color: white;">Add the DB level to the MVC Stack</span>
## <span style= "color: yellow;">Init</span>
    dotnet new mvc --no-https -o FirstConnection
    cd
    code .
## <span style= "color: yellow;">Add Packages</span>
    dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
## <span style= "color: yellow;">Create our Models</span>
### <span style= "color: white;">Pet.cs</span>
    #pragma warning disable CS8618
    using System.ComponentModel.DataAnnotations;
    namespace FirstConnection.Models;
    public class Pet
    {
        [Key]
        public int PetId {get;set;} //PK
        public string Name {get;set;}
        public string PetType {get;set;}
        public int Age {get;set;}
        public bool HasFur {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
### <span style= "color: white;">MyContext.cs</span>
    #pragma warning disable CS8618
    using Microsoft.EntityFrameworkCore;
    namespace FirstConnection.Models;

    public class MyContext : DbContext{
        public MyContext(DbContextOptions options) : base(options) {}

        //Tables for our DB
        public DbSet<Pet> Pets {get;set;}
    }
## <span style= "color: yellow;">Establish MySQL Connection (+migrate & update)</span>
### <span style= "color: white;">patch appsettings.json</span>
- Add connection string (after "Allowed Hosts")

        {
        "Logging": {
            "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
            }
        },
        "AllowedHosts": "*",
        "ConnectionStrings":
        {
            "DefaultConnection": "Server=localhost;port=3306;userid=root;password=rootroot;database=firstconnectiondb2023;" 
        }
        }

### <span style= "color: white;">patch Program.cs</span>

    using Microsoft.EntityFrameworkCore;
    using FirstConnection.Models;                                                               //Added


    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");      //Added

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<MyContext>(options =>                                         //Added
    {                                                                                           //
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));         //service that will connect to mysql
    }); 
### <span style= "color: white;">(console) db migrate</span>
- dotnet ef migrations add FirstMigration

        piers@PiyaLap MINGW64 /c/C#/newMVC/FirstConnection (main)
        $ dotnet ef migrations add FirstMigration -v
        Using project 'C:\C#\newMVC\FirstConnection\FirstConnection.csproj'.
        Using startup project 'C:\C#\newMVC\FirstConnection\FirstConnection.csproj'.
        Writing 'C:\C#\newMVC\FirstConnection\obj\FirstConnection.csproj.EntityFrameworkCore.targets'...
        dotnet msbuild /target:GetEFProjectMetadata /property:EFProjectMetadataFile=C:\Users\piers\AppData\Local\Temp\tmpE26.tmp /verbosity:quiet /nologo C:\C#\newMVC\FirstConnection\FirstConnection.csproj
        Writing 'C:\C#\newMVC\FirstConnection\obj\FirstConnection.csproj.EntityFrameworkCore.targets'...
        dotnet msbuild /target:GetEFProjectMetadata /property:EFProjectMetadataFile=C:\Users\piers\AppData\Local\Temp\tmp1098.tmp /verbosity:quiet /nologo C:\C#\newMVC\FirstConnection\FirstConnection.csproj
        Build started...
        dotnet build C:\C#\newMVC\FirstConnection\FirstConnection.csproj /verbosity:quiet /nologo

        Build succeeded.
            0 Warning(s)
            0 Error(s)

        Time Elapsed 00:00:01.25
        Build succeeded.
        dotnet exec --depsfile C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.deps.json --additionalprobingpath C:\Users\piers\.nuget\packages --runtimeconfig C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.runtimeconfig.json C:\Users\piers\.dotnet\tools\.store\dotnet-ef\7.0.10\dotnet-ef\7.0.10\tools\net6.0\any\tools\netcoreapp2.0\any\ef.dll migrations add FirstMigration --assembly C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.dll --project C:\C#\newMVC\FirstConnection\FirstConnection.csproj --startup-assembly C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.dll --startup-project C:\C#\newMVC\FirstConnection\FirstConnection.csproj --project-dir C:\C#\newMVC\FirstConnection\ --root-namespace FirstConnection --language C# --framework net7.0 --nullable --working-dir C:\C#\newMVC\FirstConnection --verbose
        Using assembly 'FirstConnection'.
        Using startup assembly 'FirstConnection'.
        Using application base 'C:\C#\newMVC\FirstConnection\bin\Debug\net7.0'.
        Using working directory 'C:\C#\newMVC\FirstConnection'.
        Using root namespace 'FirstConnection'.
        Using project directory 'C:\C#\newMVC\FirstConnection\'.
        Remaining arguments: .
        Finding DbContext classes...
        Finding IDesignTimeDbContextFactory implementations...
        Finding application service provider in assembly 'FirstConnection'...
        Finding Microsoft.Extensions.Hosting service provider...
        Using environment 'Development'.
        Using application service provider from Microsoft.Extensions.Hosting.
        MySqlConnector.MySqlException (0x80004005): Access denied for user 'root'@'localhost' (using password: YES)
        at MySqlConnector.Core.ServerSession.SendClearPasswordAsync(String password, IOBehavior ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/Core/ServerSession.cs:line 771
        at MySqlConnector.Core.ServerSession.SwitchAuthenticationAsync(ConnectionSettings cs, String password, PayloadData payload, IOBehavior ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/Core/ServerSession.cs:line 739
        at MySqlConnector.Core.ServerSession.ConnectAsync(ConnectionSettings cs, MySqlConnection connection, Int32 startTickCount, ILoadBalancer loadBalancer, IOBehavior ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/Core/ServerSession.cs:line 550
        at MySqlConnector.Core.ConnectionPool.ConnectSessionAsync(MySqlConnection connection, String logMessage, Int32 startTickCount, IOBehavior ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/Core/ConnectionPool.cs:line 363
        at MySqlConnector.Core.ConnectionPool.GetSessionAsync(MySqlConnection connection, Int32 startTickCount, IOBehavior ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/Core/ConnectionPool.cs:line 94
        at MySqlConnector.Core.ConnectionPool.GetSessionAsync(MySqlConnection connection, Int32 startTickCount, IOBehavior ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/Core/ConnectionPool.cs:line 124
        at MySqlConnector.MySqlConnection.CreateSessionAsync(ConnectionPool pool, Int32 startTickCount, Nullable`1 ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/MySqlConnection.cs:line 915
        at MySqlConnector.MySqlConnection.OpenAsync(Nullable`1 ioBehavior, CancellationToken cancellationToken) in /_/src/MySqlConnector/MySqlConnection.cs:line 406
        at MySqlConnector.MySqlConnection.Open() in /_/src/MySqlConnector/MySqlConnection.cs:line 369
        at Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(String connectionString)
        at Program.<>c__DisplayClass0_0.<<Main>$>b__0(DbContextOptionsBuilder options) in C:\C#\newMVC\FirstConnection\Program.cs:line 13
        at Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.<>c__DisplayClass1_0`2.<AddDbContext>b__0(IServiceProvider p, DbContextOptionsBuilder b)
        at Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.CreateDbContextOptions[TContext](IServiceProvider applicationServiceProvider, Action`2 optionsAction)
        at Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.<>c__DisplayClass17_0`1.<AddCoreServices>b__0(IServiceProvider p)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite callSite, RuntimeResolverContext context)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.DynamicServiceProviderEngine.<>c__DisplayClass2_0.<RealizeService>b__0(ServiceProviderEngineScope scope)
        at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
        at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
        at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider provider)
        at Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.<>c__17`1.<AddCoreServices>b__17_1(IServiceProvider p)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite callSite, RuntimeResolverContext context)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitIEnumerable(IEnumerableCallSite enumerableCallSite, RuntimeResolverContext context)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite callSite, RuntimeResolverContext context)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
        at Microsoft.Extensions.DependencyInjection.ServiceLookup.DynamicServiceProviderEngine.<>c__DisplayClass2_0.<RealizeService>b__0(ServiceProviderEngineScope scope)
        at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
        at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
        at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider provider)
        at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.FindContextTypes()
        at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.FindContextType(String name)
        at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.CreateContext(String contextType)
        at Microsoft.EntityFrameworkCore.Design.Internal.MigrationsOperations.AddMigration(String name, String outputDir, String contextType, String namespace)
        at Microsoft.EntityFrameworkCore.Design.OperationExecutor.AddMigrationImpl(String name, String outputDir, String contextType, String namespace)
        at Microsoft.EntityFrameworkCore.Design.OperationExecutor.AddMigration.<>c__DisplayClass0_0.<.ctor>b__0()
        at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.<>c__DisplayClass3_0`1.<Execute>b__0()
        at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.Execute(Action action)
        Access denied for user 'root'@'localhost' (using password: YES)

#### <span style= "color: red;">The prior code was a migrate with a bad Workbench login @ appsettings.json, second is correct user/pass</span>
    piers@PiyaLap MINGW64 /c/C#/newMVC/FirstConnection (main)
    $ dotnet ef migrations add FirstMigration -v
    Using project 'C:\C#\newMVC\FirstConnection\FirstConnection.csproj'.
    Using startup project 'C:\C#\newMVC\FirstConnection\FirstConnection.csproj'.
    Writing 'C:\C#\newMVC\FirstConnection\obj\FirstConnection.csproj.EntityFrameworkCore.targets'...
    dotnet msbuild /target:GetEFProjectMetadata /property:EFProjectMetadataFile=C:\Users\piers\AppData\Local\Temp\tmp4F17.tmp /verbosity:quiet /nologo C:\C#\newMVC\FirstConnection\FirstConnection.csproj
    Writing 'C:\C#\newMVC\FirstConnection\obj\FirstConnection.csproj.EntityFrameworkCore.targets'...
    dotnet msbuild /target:GetEFProjectMetadata /property:EFProjectMetadataFile=C:\Users\piers\AppData\Local\Temp\tmp515A.tmp /verbosity:quiet /nologo C:\C#\newMVC\FirstConnection\FirstConnection.csproj
    Build started...
    dotnet build C:\C#\newMVC\FirstConnection\FirstConnection.csproj /verbosity:quiet /nologo

    Build succeeded.
        0 Warning(s)
        0 Error(s)

    Time Elapsed 00:00:01.24
    Build succeeded.
    dotnet exec --depsfile C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.deps.json --additionalprobingpath C:\Users\piers\.nuget\packages --runtimeconfig C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.runtimeconfig.json C:\Users\piers\.dotnet\tools\.store\dotnet-ef\7.0.10\dotnet-ef\7.0.10\tools\net6.0\any\tools\netcoreapp2.0\any\ef.dll migrations add FirstMigration --assembly C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.dll --project C:\C#\newMVC\FirstConnection\FirstConnection.csproj --startup-assembly C:\C#\newMVC\FirstConnection\bin\Debug\net7.0\FirstConnection.dll --startup-project C:\C#\newMVC\FirstConnection\FirstConnection.csproj --project-dir C:\C#\newMVC\FirstConnection\ --root-namespace FirstConnection --language C# --framework net7.0 --nullable --working-dir C:\C#\newMVC\FirstConnection --verbose
    Using assembly 'FirstConnection'.
    Using startup assembly 'FirstConnection'.
    Using application base 'C:\C#\newMVC\FirstConnection\bin\Debug\net7.0'.
    Using working directory 'C:\C#\newMVC\FirstConnection'.
    Using root namespace 'FirstConnection'.
    Using project directory 'C:\C#\newMVC\FirstConnection\'.
    Remaining arguments: .
    Finding DbContext classes...
    Finding IDesignTimeDbContextFactory implementations...
    Finding application service provider in assembly 'FirstConnection'...
    Finding Microsoft.Extensions.Hosting service provider...
    Using environment 'Development'.
    Using application service provider from Microsoft.Extensions.Hosting.
    Found DbContext 'MyContext'.
    Finding DbContext classes in the project...
    Using context 'MyContext'.
    info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
        Entity Framework Core 6.0.3 initialized 'MyContext' using provider 'Pomelo.EntityFrameworkCore.MySql:6.0.1' with options: ServerVersion 8.0.33-mysql
    Finding design-time services referenced by assembly 'FirstConnection'...
    Finding design-time services referenced by assembly 'FirstConnection'...
    No referenced design-time services were found.
    Finding design-time services for provider 'Pomelo.EntityFrameworkCore.MySql'...
    Using design-time services from provider 'Pomelo.EntityFrameworkCore.MySql'.
    Finding IDesignTimeServices implementations in assembly 'FirstConnection'...
    No design-time services were found.
    Writing migration to 'C:\C#\newMVC\FirstConnection\Migrations\20230918040924_FirstMigration.cs'.
    Writing model snapshot to 'C:\C#\newMVC\FirstConnection\Migrations\MyContextModelSnapshot.cs'.
    Done. To undo this action, use 'ef migrations remove'
### <span style= "color: white;">(console) db update</span>
    $ dotnet ef database update
    Build started...
    Build succeeded.
    info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
        Entity Framework Core 6.0.3 initialized 'MyContext' using provider 'Pomelo.EntityFrameworkCore.MySql:6.0.1' with options: ServerVersion 8.0.33-mysql
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE DATABASE `CSFirstConnectionDB`;
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (16ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE `__EFMigrationsHistory` (
            `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
            `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
            CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
        ) CHARACTER SET=utf8mb4;
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='CSFirstConnectionDB' AND TABLE_NAME='__EFMigrationsHistory';
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        SELECT `MigrationId`, `ProductVersion`
        FROM `__EFMigrationsHistory`
        ORDER BY `MigrationId`;
    info: Microsoft.EntityFrameworkCore.Migrations[20402]
        Applying migration '20230918040924_FirstMigration'.
    Applying migration '20230918040924_FirstMigration'.
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        ALTER DATABASE CHARACTER SET utf8mb4;
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (11ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE `Pets` (
            `PetId` int NOT NULL AUTO_INCREMENT,
            `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
            `PetType` longtext CHARACTER SET utf8mb4 NOT NULL,
            `Age` int NOT NULL,
            `HasFur` tinyint(1) NOT NULL,
            `CreatedAt` datetime(6) NOT NULL,
            `UpdatedAt` datetime(6) NOT NULL,
            CONSTRAINT `PK_Pets` PRIMARY KEY (`PetId`)
        ) CHARACTER SET=utf8mb4;
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
        VALUES ('20230918040924_FirstMigration', '6.0.3');
    Done.
## <span style= "color: yellow;">Db config cont.(@HomeController)</span>

    (dependencies and namespaces have not changed...abbreviated...)

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;                             //added- create another variable for MyContext, then include it to the constructor below

        public HomeController(ILogger<HomeController> logger, MyContext context)   //" , MyContext context " added
        {
            _logger = logger;
            _context = context;                                 // added (research.this)- so that we can start asking for information.
        }

        public IActionResult Index()
        {
            List<Pet> AllPets = _context.Pets.ToList();         // added- Select * from Pets;
            return View();
        }

        public IActionResult Privacy(Did not change...abbreviated....)
    }

## <span style= "color: yellow;">Conclusion</span>

- Now we can: 
    - <span style= "color: white;"> "dotnet watch run" - Access Index.cshtml that theoretically would have our select * from Pets view</span>
    - <span style= "color: white;"> Within sqlWorkbench - Verify DB csfirstconnectiondb exists</span>