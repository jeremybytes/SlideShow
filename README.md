# Slide Show Replacement

This repository contains a replacement for the Windows 11 photos slideshow (since the functionality is reduced from the Windows 10 version).

## Features  
Version 0.1.0
* Dialog to choose folder with images
* Auto-sizes images to the window size
* Shuffles images into a random order
* Auto-advance set to 10 seconds (changeable in code)
* 'Space' to pause the auto-advance
* 'Enter' or 'Right Arrow' to manually advance
* 'Left Arrow' to go to previous
* "Esc" to exit

*Note: the feature set is minimal for what my immediate needs. Potential features are listed below.*

## Running
Download the code.

In the "MainWindow.xaml.cs" file, you can modify the starting folder for your images:

```c#
var location = @"C:\Users\jerem\Pictures\Idle Album";
```

In addition, you can change the auto-advance setting by changing the "Interval" in the "MainWindow.xaml.cs" file:

```c#
Interval = new System.TimeSpan(0, 0, 10)
```

From the command line, type "dotnet run" to build and run the application.

## Potential Features
* Configuration to set auto-advance interval
* Configuration to set starting folder location
* "Installation" to allow right-click in a folder with images to start the application
* UI to change the auto-advance interval
* UI to pause the auto-advance
* UI to manually advance / return to previous

## 