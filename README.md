# Aksia

A single page .net MVC project for managing (view, create, delete) user contacts, along with their addresses.

Contact items should be displayed in a cards view with addresses as details within them. There should be an option to see address information on a google map pane displayed besides the contact items.

The application is being split into 4 projects.

TheAksia which is the web app containing the actual MVC project

The Business Layer, on which all of the business logic is being implemented. Validation, authentication and all of the other data-functionality that is needed by the web app is being implemented there.

The Data Access, which provides access to the data layer in the SQL Server. A very simple ORM functionality has been used to communicate with the database.

The Commons which provides some application commonly used functionality across the application, like localization or data access gateway.

The whole project is in development phase. 

Most of the data access has been implemented

Some of the business layer and web app functionality have been implemented

The commons project is in an early stage.
