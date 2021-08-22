# AspnetCoreAuth_RolandGuijt

<br />Chapter 2 Understanding Authenticationa and Authorization
<ul> the sequence is important
<li>app.UseRouting();</li>
<li>app.UseAuthentication();</li>
<li>app.UseAuthorization();</li>
</ul>
<ul>Secure the password
<li>public User GetByUsernameAndPassword(string username, string password)</li>
</ul>

![ClaimPrincipleIdentityClaim](https://user-images.githubusercontent.com/64368109/130358579-48c7c631-8cca-4537-a831-ff805e107710.png)

![Cookies](https://user-images.githubusercontent.com/64368109/130358725-4483ff83-2e95-43c7-ba32-52dcdeb16ebf.png)

-  check user cookie for login 
<br />
Or inherited from public class ClaimsTransformer : IClaimsTransformation
<br />      
```
<div class="col-md-4">
            @if (User.Identity.IsAuthenticated)
            {
                <h3>Hi @User.Identity.Name!</h3>
                <a asp-controller="Account" asp-action="Logout" class="btn btn-primary">Logout</a>
            }
            else
            {
                <h3>Login here: </h3>
                <a asp-controller="Account" asp-action="Login" class="btn btn-primary">Login</a>
       
            }
  </div>
  ```

![OAuthOpenID](https://user-images.githubusercontent.com/64368109/130359405-9862b075-d054-47e2-a18a-2a68b83dd342.png)
-  Manager google config using right click project -> Manger User Secrects
![UseSecretId](https://user-images.githubusercontent.com/64368109/130359988-a7c22522-5b0f-4e7c-8d99-f85d6a0e903c.png)

-  Multiple authentication

![MultipleLogin](https://user-images.githubusercontent.com/64368109/130359997-d8919d47-33d4-4bd6-81a6-7d6e86dbc9f7.png)


Chapter 3 Implementing authentication with aspnet core identity
-  Create project with Identity authentication
-  Login features
![LoginFeatures](https://user-images.githubusercontent.com/64368109/130360484-2ec9de2b-0ea4-47bf-89e9-de54eaa0b6f6.png)
```
    public class ApplicationUser : IdentityUser
    {
        public DateTime CareerStartedDate { get; set; }
        public string FullName { get; set; }
    }
 ```
-  other customized indentity stores
<br />https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-custom-storage-providers?view=aspnetcore-5.0
<br />https://4sh.nl/IdentityConfigurationc

-  Retrofit Identity pages (since default pages from Areas->Indentity + Microsoft.AspNetCore.Identity.UI)
![CustomizeIdentityPages](https://user-images.githubusercontent.com/64368109/130361224-66c59d09-3132-4e3d-81ab-4d72addd975d.png)
![CustomizeIdentityPage1](https://user-images.githubusercontent.com/64368109/130361277-481dd85b-e11e-4e0f-8f49-9aba9f109114.png)<br />

![CustomizeIdentityPage2](https://user-images.githubusercontent.com/64368109/130361386-4087e10c-c7f6-4f7b-9bc0-2c2e56df3f0e.png)

-  Customized claims
<br /> or public class ClaimsTransformer : IClaimsTransformation
```
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options
            ): base (userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> 
            GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("CareerStarted",
                user.CareerStartedDate.ToShortDateString()));
            identity.AddClaim(new Claim("FullName",
                user.FullName));

            return identity;
        }
```
![CustomizedClaims](https://user-images.githubusercontent.com/64368109/130365063-ee13fb87-0b3e-4f3c-95ef-3e5a5757bd4a.png)

-  Customize role or inherit RoleIdentity
![RoleIsClaims](https://user-images.githubusercontent.com/64368109/130365350-37b44850-43d1-4423-ae95-79894a7fb7da.png)
```
public class IdentityHostingStartup : IHostingStartup

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ConfArchWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration
                            .GetConnectionString("ConfArchWebContextConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ConfArchWebContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                    ApplicationUserClaimsPrincipalFactory>();
                services.AddTransient<IEmailSender, EmailSender>();

                services.AddAuthentication()
                    .AddGoogle(o =>
                    {
                        o.ClientId = "686977813024-1pabqkfoar3btu6tsh7puhu3pogcivi0.apps.googleusercontent.com";
                        o.ClientSecret = context.Configuration["Google:ClientSecret"];
                    });
            });
        }
        
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options
            ): base (userManager, roleManager, options)
        {
        }
        
```
-  Send email
![image](https://user-images.githubusercontent.com/64368109/130365553-b2f1bc9d-06bb-4c94-8437-4ca34f5cb835.png)

-  two factor authentication to use QR code scan
![image](https://user-images.githubusercontent.com/64368109/130365635-81f125d9-0493-4727-a261-33f6a822b636.png)
https://4sh.nl/qrcodejs
