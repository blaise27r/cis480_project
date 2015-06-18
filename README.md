# cis480_project
This is the new project repo.

I added a .gitignore from https://github.com/github/gitignore/blob/master/VisualStudio.gitignore
This should take care of all of the ide config files and whatnot.
Please let someone know in the slack room if .gitignore needs to be altered

To start working on the project fork this repository, and clone your repository. To get your changes merged issue a pull request to this repository. If you have questions on how to use git, github, .NET or anything else, the slack room would be a good place for them.

The basic process for creating the database is to use the Powershell Package Manager Console in visual studio. Run "enable-migrations". This may giving you an error saying to need to specify a context. Use the course context. "Add-migration initial" and "update-database" should create the database. If changes are made to the database, delete the Migrations folder that was created with this process, and repeat the process.
