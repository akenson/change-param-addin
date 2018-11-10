# turn-blue-addin

This Add-in is intented as a very simple Inventor add-in to show how to take an existing Inventor Add-in and turn it into an AppBundle as a learning excersize for AU 2018.

1. Start Visual Studio 2017 or later as Administrator 
2. Open TurnBlueAddIn.sln in Visual Studio
3. Build solution
4. Copy Autodesk.TurnBlue.Inventor.addin to %PROGRAMDATA%/Autodesk/Inventor \<version\>/Addins
5. Copy the ouptut dll in bin/<Config>/TurnBlueAddIn.dll that you built in step 2 to %PROGRAMFILES%/Autodesk/Inventor \<version\>/Bin
6. Run Inventor, you should see a Message Box stating that the Turn Blue add-in is enabled.
7. Open a Part
8. Got to the View Tab and Appearance Pane. 
9. Click on the "Turn Blue" button and it should turn your part blue
