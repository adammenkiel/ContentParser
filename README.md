# ContentParser

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white) 
![Last Commit](https://img.shields.io/github/last-commit/adammenkiel/ContentParser?style=for-the-badge) 
![Activity](https://img.shields.io/github/commit-activity/m/adammenkiel/ContentParser?style=for-the-badge)

# Table of Contents

- [Project description](#project-description)
- [RestAPI documentation](#restapi-documentation)
  - [POST /api/v1/parse-content](#post-apiv1parse-content)
- [Run](#run)
- [Tests](#tests)
- [Stack](#stack)
- [Contact](#contact)

# Project description

Projects implements HTTP endpoint responsible for parsing content (Json or CSV) into standardized format.

# RestAPI documentation

## POST /api/v1/parse-content

Description: Decoding fixed at request type of content from Base64 format, parsing into JSON, counts element/lines and returns information at JSON form.

Requires:

- type: Type of content, supported formats: ``INTERNAL_JSON``, ``CSV``
- content: Base64 encoded content, at CSV format if content type is CSV or JSON format if content type is INTERNAL_JSON.

Returns:

- If data is correct returns JSON response contains "status" (success), "count" - counts lines/elements in RootElement, "encodedFormat" - string with encoded context represented as JSON in string
- If data is incorrect returns JSON response contains "status" (failed), "errorMessage" - message of error

# Run

To run project use ``dotnet run --project "src/API/API.csproj"``

# Tests

To run tests use ``dotnet test``

# Stack

- C#
- ASP.NET Core
- MediatR
- .NET
- xUnit
- CsvHelper

# Contact

- Email 1: akmenkiel@gmail.com
- Email 2: publicprojectsmenkiel@gmail.com
