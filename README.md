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
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-custom-storage-providers?view=aspnetcore-5.0
