<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
*** reference: https://github.com/othneildrew/Best-README-Template/edit/master/README.md
-->

[![LinkedIn][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Nuget](https://img.shields.io/nuget/v/Hgindra.AspnetCore.SecurityHeaders)](https://www.nuget.org/packages/Hgindra.AspnetCore.SecurityHeaders/)

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)



<!-- ABOUT THE PROJECT -->
## About The Project

This project contains few of the extension methods to improve the security of ASP.NET Core Web Application. Most the extension methods are about adding security headers to the requests that blocks or improves your application's security.

### Problems
There are several security problems that our web application can face when our app is available on the internet. Security challenges like cross site scripting, clickjacking, content security, etc are some of the common issues one can come across.

* Allows a registered air conditioning unit to log its sensor readings
* Allows an system user to keep track of the readings and get notified if any device readings are beyond the safety benchmark so that appropriate actions can be taken on time

I found this amazing [article](https://blog.elmah.io/the-asp-net-core-security-headers-guide/) that talks about the security headers in ASP.NET Core. You can refer to this article to understand better


<!-- GETTING STARTED -->
## Getting Started

To get started, here are some of the topics that you must be familiar with i.e. what it is, how it works, how can it be integrated into the ecosystem.

*  ASP.NET Core
* [ASP.NET Security](https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-5.0)

## Usage

Like mentioned earlier, there are several extension methods in the project. Here are few examples of how to use the methods

#### This method adds X-Frame header to the response
```

app.AddXFrameOptionHeader();

```
There are different options also available that you can use to configure X-Frame options

#### Another example is to add Referrer policy to the headers
```

app.AddReferrerPolicyHeader(ReferrerPolicy.NoReferrerWhenDowngrade);

```
There are different referrer policy options available to choose from.

#### Another example to add Content Security Policy Headers

```
            app.AddContentSecurityPolicyHeader(x =>
                 {
                     x.AddScripts()
                     .AllowInline()
                     .AllowSelf();

                     x.AddAlways();

                     x.AddFrames().DenyAll();
                     x.AddImages().DenyAll();
                     x.AddMedia().DenyAll();

                     x.AddStylesheets()
                     .AllowInline()
                     .AllowSelf();

                     x.AddConnect()
                     .AllowSelf();
                 }); 
```



#### You can refer to `samples.cs` file for complete list of extension methods and its descriptions.


<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/harshitgindra/Hgindra.AspnetCore/issues) for a list of proposed features (and known issues).


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.


<!-- CONTACT -->
## Contact

Your Name - [@harshitgindra](https://twitter.com/harshitgindra) - harshitgindra@gmail.com

Project Link: [Hgindra.AspnetCore.SecurityHeaders](https://github.com/harshitgindra/Hgindra.AspnetCore/tree/main/Hgindra.AspnetCore.SecurityHeaders)

<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [Img Shields](https://shields.io)
* [Choose an Open Source License](https://choosealicense.com)
* [Github Readme template](https://github.com/othneildrew/Best-README-Template)




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->


[license-shield]: https://img.shields.io/github/license/harshitgindra/Hgindra.AspnetCore?style=flat-square
[license-url]: https://github.com/harshitgindra/Hgindra.AspnetCore/blob/main/LICENSE

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/harshit-gindra
