# Step1: Launch WebApi projects
```
dotnet run --project ./ProjectA/ProjectA.csproj
dotnet run --project ./ProjectB/ProjectB.csproj
```

# Step2: Call API
```
curl --location 'http://localhost:5295/httpClient/test'
```

# Step3: Monitoring ProjectA and ProjectB Logs
You will find that the cookie is set to a different value for each request. However, the ProjectB receive the same value until the `HttpMessageHandler` expires.

ProjectA Logs
```
sent cookie with value:ih-rvp=06:16:47.98;
sent cookie with value:ih-rvp=06:16:48.81;
sent cookie with value:ih-rvp=06:16:49.38;
sent cookie with value:ih-rvp=06:16:49.90;
sent cookie with value:ih-rvp=06:16:50.40;
sent cookie with value:ih-rvp=06:16:50.87;
sent cookie with value:ih-rvp=06:16:51.33;
sent cookie with value:ih-rvp=06:16:51.78;
sent cookie with value:ih-rvp=06:16:56.11;
sent cookie with value:ih-rvp=06:16:56.82;
```

ProjectB Logs
```
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
Received ih-rvp cookie value: 06:16:47.98
```


# Step4: Set UseCookies to False 
Set `UserCookies` to false and run the flow again. This time will respect the change of cookie 
```
.ConfigurePrimaryHttpMessageHandler(serviceProvider =>
 {
     return new SocketsHttpHandler
     {
         PooledConnectionLifetime = TimeSpan.FromSeconds(10),
         UseCookies = false,
     };
});
```