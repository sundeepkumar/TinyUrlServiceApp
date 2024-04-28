# TinyUrl Service 

*TinyURL* is a service in which users can create short links

### Description

TinyURL is a service in which users can create short links, such as tinyurl.com/3rp36a3s, that redirect to longer links, such as https://www.adroit-tt.com.

The service provides the following functionality: 

1. Creating and Deleting short URLs with associated long URLs.
2. Getting the long URL from a short URL.
3. Getting statistics on the number of times a short URL has been "clicked" i.e. the number of times its long URL has been retrieved.
4. Entering a custom short URL or letting the app randomly generate one, while maintaining uniqueness of short URLs.


### Installing and usage 

Open this project in your Visual Studio 2022 
The program can be run in any ofthe following ways :
1. TinyUrlApp.exe <LongUrl>  //Run program with only longURL , prints a short url , double clicks and deletes the URL  
2. TinyUrlApp.exe <LongUrl>  <ShortUrl> //Run program with  longURL  and a short URL , prints a short url , double clicks and deletes the URL
3. TinyUrlApp.exe //Run program with no command line arguments , asks the user for a longURL and an optional short Url  , prints a short url , double clicks and deletes the URL


## Running the tests

The test project has an has unit tests in the file *TinyUrlServiceTests.cs* 

## License

This project is licensed under the MIT License 
