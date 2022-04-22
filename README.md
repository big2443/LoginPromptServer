# WGT Login Prompt Excersise

This is a simple web server for a login prompts service. A login prompt consists of an image URL and caption that is displayed by a mobile client application (game) when the user logs in. A login prompt is similar to an ad, promoting game features and content.

The web server implements both a JSON-based API (for the mobile client), and a web-based admin interface (for human content managers). We'd like you to make a some enhancements to the existing code. (See Tasks below.)


## Prerequisites
* .NET 5


## Getting started
1. Unzip `LoginPromptServer.zip`
2. Change to the project directory: `cd LoginPromptServer`
3. Enter `dotnet run` to download dependencies and start the web server.
4. Open http://localhost:9000/ in your web browser to see the Admin UI.
5. At this point, you should see a basic HTML admin page titled `Login Prompts`. You can test the client API by opening http://localhost:9000/api/loginPrompt


## Tasks
Please complete these tasks in order.
1. The client application should be able to fetch a random login prompt when the user logs in. Please implement this in the `/api/loginPrompt/next` endpoint.
2. Users are complaining about seeing the same login prompts too often. Modify the server to allow content creators to define a quiet period for each login prompt. After the server returns a login prompt for a user, that login prompt should not appear again until the quiet period has elapsed. Please implement this in the `/api/loginPrompt/next/{userId}` endpoint.

To get you started, we've initialized the database with some sample login prompts. Your code, however, should work with any collection of login prompts.


## Useful info
* The backing in-memory database is transient
* Database setup and initialization occurs in `LoginPromptServer/Models/*.cs`
* Additional tables can be added and existing tables modified if desired
