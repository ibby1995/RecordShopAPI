# Record Shop API

## Overview
A backend API for the Northcoders Record Shop inventory system, allowing the shop to store, query and update their album stock.

## How to Run
1. Open the solution in Visual Studio
2. Press F5 to run
3. Navigate to https://localhost:{port}/swagger to interact with the API

## Endpoints
- GET /albums - Get all albums in stock
- GET /albums/{id} - Get a single album by ID
- POST /albums - Add a new album
- PUT /albums - Update an album
- DELETE /albums/{id} - Delete an album
- GET /health - Check the health of the API

## Assumptions
- Each album has a name, artist, genre, release year and stock quantity
- The API uses an in-memory database for development

## Approach
- Built using ASP.NET Core Web API with .NET 8
- Follows separation of concerns with Models, Repository, Services and Controllers layers
- Unit tested using NUnit and Moq

## Future Thoughts
- Implement a real SQL Server database
- Add the nice-to-have features such as searching by artist, genre and release year
- Add authentication