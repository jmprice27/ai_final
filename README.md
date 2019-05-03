# ai_final

Jeff Quattrociocchi
Final Project

A warehouse robotics simulation for experimenting with AI algorithms using .NET Standard libraries.

Inspired by the Berkeley cs pcaman projects
http://inst.eecs.berkeley.edu/~cs188/pacman/pacman.html

Github page:
https://github.com/jmprice27/ai_final.git

Work was generally broken up by the projects in the solution:

Final.Agent:
	Author: 	Jack Price, Jeff Quattrociocchi
	Description: 	Classes defining agents and agent states, as well as the overall control module for the agents.
			General architecture based on the Berkeley AI pacman agents

Final.Analysis:
	Author: 	Jeff Quattrociocchi
	Description: 	Contains classes for recording and analyzing data.
			Mostly implemented in .Jsonify methods in relevant classes throughout the project

Final.Common:
	Author: 	Jack Price, Jeff Quattrociocchi
	Description: 	General utility classes used in multiple projects

Final.Warehouse:
	Author: 	Jack Price
	Decription: 	Contains the classes needed for creating the warehouse environment.
			It generates the nodes and edges used to navigate in the environment, as well as classes used to assist in distance calculations
Unit Tests:
	Author: Jack Price
	Description: 	Tests needed for the above projects
