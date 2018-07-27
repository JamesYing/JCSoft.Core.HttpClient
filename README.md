# What is it?

JCsoft.Core.HttpClient is a System.Net.HttpClient Helper Class library, it's based on .Net Standard 2.0.

# How use?

Step 1: register helper server in `Startup.cs`
```
 services.AddHttpClientService();
```

Step 2: DI to  your class, like this:
```
private readonly IHttpHelper _httpHelper;

public HomeController(IHttpHelper httpHelper)
{
    _httpHelper = httpHelper;
}
```

Step 3: let's do it.

Get¡¢Post¡¢Put¡¢Delete always return a string or object. like :

GetAsync:
```
 var response = await _httpHelper.GetAsync(url);
```
GetAsync<T>:
```
 var response = await _httpHelper.GetAsync<T>(url);
```

# Methods:

Method Name | params | return | note
--|--|--|--
GetAsync|url,requestparams, headers| string| return remote url content.
GetAsync<T>|url,requestparams, headers| T | string Deserialize Object T
PostAsync|url,data, headers, encoding| string| return remote url content.
PostAsync<T>|url,data, headers, encoding| T | string Deserialize Object T
PutAsync|url,data, headers, encoding| string| return remote url content.
PutAsync<T>|url,data, headers, encoding| T | string Deserialize Object T
DeleteAsync|url,requestparams, headers| string| return remote url content.
DeleteAsync<T>|url,requestparams, headers| T | string Deserialize Object T
