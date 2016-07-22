# FileIndexer

A file indexing program. 
The purpose of the application is to be able to index a folder and all of its contents recursively. 
Once indexed the user can browse the contents in a user interface and quickly see handful information about files and folders.
The user should also be able to filter results, save them and import them.

Description:
- General
	- Take a folder path as input.
	- Scan for all the files inside the folder or its subfolders.
	- Create an index in memory (some kind of collection). The index should include filename, size and location.
	- Provide a graphical user interface
	- The program must be capable of being started from the command line with given path as argument (the path to index)
	- There should be a graphical menu item for selecting the path - it is supposed to be used when the application is started without command line arguments

- User interface
	- A menu on top
	- A toolbar with filters below the menu
	- A split panel below the toolbar
		- Left - a tree view of the indexed path
		- Right - information about currently selected item
	- Status bar on the bottom - display selected file/directory path
	- Hot keys should be available for menu commands		

- Import/Export
	- Provide the ability to save the index to file.
	- Export must export the indexed file list - this can provide a mean to compare the contents of a path at two different dates
	- Let the user choose where to export and filename
	- Provide the ability to load the index from file

- Searching/Filtering
	- Search in indexed files by name, size (lower than, bigger than), creation date, last modified date, file extension
	- When typing 'Enter' in the search field the search operation should be executed
	- When selected by size (accept only number and MB,KB,GB behind)

- Visualisation
	- Display files in a tree view - nodes are directories, leafs are files
	- Select in tree view => load in right panel only files from that directory
