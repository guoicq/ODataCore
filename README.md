# ODataCore
Sample Project about oData with ASP.net Core without Entity Framework

Using .net Core 1.1, with the Microsoft.AspNetCore.OData.vNext libraries, I am able to get an OData endpoint working with my simple controller.

To install library referenced by this project, run the following command in the Package Manager Console
.NETFramework,Version=v4.6.1

Install-Package Microsoft.AspNetCore.OData.vNext -Pre

Install-Package Microsoft.AspNetCore -Version 1.1.1

Install-Package Microsoft.AspNetCore.Mvc -Version 1.1.2

Install-Package Microsoft.EntityFrameworkCore -Version 1.1.2

Install-Package Microsoft.ApplicationInsights.AspNetCore -Version 2.0.0

Install-Package Microsoft.Extensions.Logging.Debug -Version 1.1.1



Using Postman, or Chrome, you can then try the OData API:

http://localhost:5555/odata/Peoples?$top=5

http://localhost:5555/odata/Peoples?$top=5&$skip=5

http://localhost:5555/odata/Peoples('001')/Trips
