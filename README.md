# CIS 480 Project

Steven Fisher  
Dzmitry Dabravolski

## Tools

Visual Studio 2013  
Github for Windows/Mac or Git Shell

## Changes

**AssignmentController.cs**

Index action takes an argument for a nullable courseId
If that courseId is null will return the HttpNotFound view (404 error)

The current course the user is browsing will be passed to the view in order to simplify browsing through breadcrumbs.

**Assigment/Index.cshtml (Assignments Index View)**

Breadcrumb added will link to the appropriate course info page for the current assignment as well show the name of that course.

**Course/Index.cshtml (Course Index View)**

Link added for assignments so the user can easily browse to that courses assignments page.

**EnablingObjectiveController.cs**

Since courseId and objectiveId are both nullable arguments we added in a 404 error for when there is neither argument supplied.

**EnablingObjective/Index.cshtml (EnablingObjectives Index View)**

Changed the links text for the current objective in breadcrumbs.


## Entity Framework

A framework for accessing data easily in this instance is built on using a local database file. When the project is compiled you will see a .mdf file in the App_Data directory of the root project directory.

A known problem is that the V11.0 database instance will stay connected to your data connections in Visual Studio. To fix this open the Nuget package manager console and enter the commands below sequentially.

>sqllocaldb p v11.0  
>sqllocaldb d v11.0  
>sqllocaldb c v11.0

These commands will stop the v11.0 instance then delete and recreate it. You will have to compile the project in order to generate the .mdf file again.

## Todo

**Units**

Units needs to be implemented. With Entity Framework will have to add a unitId to the assigment model as a foreign key.

Add views for units this includes create, delete, details, edit, and index. A controller will also have to be made.
