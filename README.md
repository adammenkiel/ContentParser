# ContentParser

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white) 
![Last Commit](https://img.shields.io/github/last-commit/adammenkiel/ContentParser?style=for-the-badge) 
![Activity](https://img.shields.io/github/commit-activity/m/adammenkiel/ContentParser?style=for-the-badge)

# Table of Contents

- [Project description](#project-description)
- [RestAPI documentation](#restapi-documentation)
  - [POST /api/v1/parse-content](#post-apiv1parse-content)
- [Configuration](#configuration)
- [Run](#run)
- [Tests](#tests)
- [Stack](#stack)
- [Contact](#contact)

# Project description

Project implements HTTP endpoint responsible for parsing content (Json or CSV) into standardized format.

# RestAPI documentation

## POST /api/v1/parse-content

Description: Decoding fixed at request type of content from Base64 format, parsing into JSON, counts element/lines and returns information at JSON form.

Required headers:

``Content-Type: application/json``

Content requires:

- type: Type of content, supported formats: ``INTERNAL_JSON``, ``CSV``
- content: Base64 encoded (from UTF-8) content, at CSV format if content type is ``CSV`` or JSON format if content type is ``INTERNAL_JSON``.

Returns:

- If data is correct returns JSON response contains ``status`` (success), ``count`` - counts lines/elements in RootElement, ``encodedContent`` - string with encoded context represented as JSON in string
- If data is incorrect returns JSON response contains ``status`` (failed), ``errorMessage`` - message of error

Example:

When you send ``POST /api/v1/parse-content`` with the following JSON:
```json
{
    "type": "INTERNAL_JSON",
    "content": "Wwp7InRleHQiOiJIZWxsbyB3b3JsZCJ9LAp7InRleHQiOiJCcm9rZW4ifSwKeyJ0ZXh0IjoiMTIzIn0KXQ=="
}
```
You will receive this response:
```json
{
    "status": "success",
    "count": 3,
    "encodedContent": "[{\"text\":\"Hello world\"},{\"text\":\"Broken\"},{\"text\":\"123\"}]"
}
```

# Configuration

Configuration files could be found at /src/API directory:
- ``appsettings.Development.json`` - An configuration file responsible for runtime in Development mode
- ``appsettings.json`` - An configuration base file

Settings:
- ``MaxDepth`` - Setting responsible for max depth of JSON nesting (set -1 value disables this property)
- ``MaxContentSize`` - Setting responsible for maximum size of encoded content (set -1 value disables this property)

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
