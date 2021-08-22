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
