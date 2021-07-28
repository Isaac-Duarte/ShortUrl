# ShortUrl
A simple asp.net 5 application that allows a client to post to a domain returning a shortened url that redirects to the given url. The fozie.net endpoint is avalible for public use!**

The idea is to be able to copy urls and shorten them quickly through keyboard bindings. The current bash script will set your clipboard content to the shorten url

# Client Setup

### Linux
This isn't a set tutorial for linux operating systems as this mainly depends on what desktop enviorment you are using. However, simply make the url-shortener.bash script executable and bind a key to it.

**You will need xclip for this to work**  

### MacOS
[Go to the MacOS Wiki Page](https://github.com/Isaac-Duarte/ShortUrl/wiki/MacOS-Setup)

### Windows
Currently no support for Windows

# API Setup
In order to run this api you need to have [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) installed. (Windows, MacOS, Linux)

### Quick Start
```
git clone https://github.com/Isaac-Duarte/ShortUrl.git
cd ShortUrl
dotnet build
bin/Debug/net5.0/ShortUrl
```

### Configuration
* The appsettings.json allows to change the database connection string.
* The `Urls` part of the configuration is for binding to domains/ip addresses.
 
### *Note*
By default only SQLite will work, however if you want to use MySQL, Postgree, etc add the proper nuget packages. [Database Providers](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)

# Credits
[Fred Duarte](https://github.com/fduarte-msft) - Windows support
[Isaac Duarte](https://github.com/Isaac-Duarte) - API, Linux & MacOS Support. 
