# Hahn.ApplicatonProcess.Application
The project is written in .NET CORE as a backend and Aurelia as a frontend.

Backend
How to use:
1.	You will need the latest Visual studio 2019 and the latest .NET Core SDK
2.	Please check if you have installed the same runtime version (SDK) described in global. json
3.	The latest SDK and tools can be downloaded from https://dotnet.microsoft.com/download
4.	You can run this project in Visual Studio Code(Windows, Linux or MacOS)
5.	You need to run the following command
a.	dotnet restore
b.	dotnet run
Technologies implemented
1.	.NET Core – web Framework
2.	Entity Framework
3.	AutoMapper
4.	AutoMapper.Extension.Microsoft.DependecyInjection
5.	FluentValidation
6.	MediatR
7.	MediatR.Extension.Microsoft.DependencyInjection
8.	Swashbuckle.AspNetCore 
9.	Serilog
10.	AspNetCore.Localization
11.	EntityFrameworkCore.InMemory
12.	Microsoft.AspNetCore.Server.Kestrel.Core;

Architecture
1.	Full architecture with responsibility separation concerns
2.	Domain Driven Design
3.	Domain Events
4.	Domain Validators
5.	CQRS( Immediate Consistency)
6.	Event Sourcing
7.	Repository


Frontend
How to use:
6.	You will need the latest Aurelia-cli
7.	au-run –watch [run the command]
8.	Navigate to http://localhost:8080/
9.	You need to run the following command
c.	dotnet restore
d.	dotnet run

Technologies implemented
1.	typescript
2.	aurelia-bootstrapper
3.	aurelia-dialog
4.	aurelia-fetch-client
5.	aurelia-i18n
6.	aurelia-validation
7.	bootstrap
8.	i18next-xhr-backend
9.	wabpack

Functionality Overview
1.	After successful running the application Create New Applicant view will appear at the same time system will store all the country in local storage , by default send and reset button are disable
2.	Invalid fields are marked with red color.
3.	After successful validation send button will enable and you can submit all the data.
4.	If response from API is 201 then system will automatically navigate to list view where you will see your input information. The data shown in the list view are descending order so that you can see you last input in first row.
5.	In list view there are add button, you can click add button for data input purpose and there are two more buttons available in a table (Edit and Delete). If you want to update the information click edit button or for deleting purpose click delete button.
6.	 


