
Instruction to build and run command-line project for first task(Provide a command-line way to load the CSV file into the database):
1. Download project from following github link. https://github.com/Sailuja/UfoHotspot
2. Open the project in Visual Studio.
3. Start MySql image using docker-compose.
4. Create new mysql database Ufohotspot.
5. Change db connection string in ApplicationDbContext.cs file line 18 to point to the database created,
6.  - Import sql dump (UfoHotspot.sql in github) into the database. 
	- Or, run migration script, "update-database" in visual studio terminal to create database schema	 
7. Run the project. This will also seed the Hotspot table with five Hotspots provided.
	- Plese check database to make sure data is loaded.
8. Follow the instruction to import csv file first.
	- csv file should be located in the bin/Debug/net5.0/
	- Enter full name of the file with extension
	- Check database to make sure data has been imported correctly.
	
For second part (Provide a command-line way to produce a JSON file with all of the hotspots and any sightings within 1500 kilometers of the hotspot):
1. Run the project and enter 2.
2. Enter the name with extension like hotspot_sighting.json.
3. This should download a fine in bin/Debug/net5.0/ with all of the hotspots and any sightings within 1500 kilometers of the hotspot. 

Overview of the process followed:
Some of the technologies used are MySql, .Net Core Framework 5.0, Docker.

Fisrt step was to install Docker and download MySql image. After that I designed database schema using code first approach in Entity Framework.
I started working on first part of the task to load csv into the database by creating Sighting table then running the migration script to create relevant schema.
Then worked on the console menu to allow user select from two options. There were some data quality issues in the Sighting data set that I talk about down below.
For second task I created a Hotspot table. I then created a BaseSeeder (in Migration folder) to seed the five hotspots.
I used Haversine formula in sql query to create a View that updates the distance from each hotspot to sighting location. Worked on backend code to 
generate JSON file with all the hotspots and any sightings within 1500 kilometers of the hotspot. 

Challanges faced:
1. The main challange I faced was related to loading of unclean Sighting data. Duration column had integers, null as well as string, address in the 
 Site Location was not in same format. In order to retrieve latitude and longitude from location I had to do some research and use Regular expression. 
2. Using the Haversine formula on the front end and looping through each sighting data point would cause a performance hit as the data set grows. In order to solve this 
 I created a database View that computes distance between each sighting and hotspot so we don't have to calculate it on the front end.

Next step to finish the challange:
Since the backend has already been designed, and Sighting, Hotspot data has been loaded, building API endpoints should not take very long. 

Assumptions made:
1. Address, DurationInHours, Shape in Sighting table will be max 255 characters.
2. Comments will be max 1024 characters.

Feedback:
The task overall was very interesting. Docker compose was easy to learn and use as it was my first time using it. Instructions given for the assignment was very 
clear and concise. 

