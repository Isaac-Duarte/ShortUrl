# ShortUrl
A simple asp.net 5 application that allows a client to post to a domain returning a shortened url that redirects to the given url.

# Client Setup

## Linux
This isn't a set tutorial for linux operating systems as this mainly depends on what desktop enviorment you are using. However, simply make the url-shortener.bash script executable and bind a key to it.

## MacOS
*todo*

## Windows
*todo*

# API Setup
In order to run this api you need to have [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) installed. (Windows, MacOS, Linux)

### Quick Start
```
git clone https://github.com/Isaac-Duarte/ShortUrl.git
cd ShortUrl
dotnet build
dotnet run or bin/Debug/net5.0/ShortUrl
```

### Configuration
* The appsettings.json allows to change the database connection string.
* The `Urls` part of the configuration is for binding to domains/ip addresses.
 
## *Note*
By default only SQLite will work, however if you want to use MySQL, Postgree, etc add the proper nuget packages. [Database Providers](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)


