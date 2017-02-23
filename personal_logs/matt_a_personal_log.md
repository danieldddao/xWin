# Matt Andress personal log for sep

## 2/1/2017
* Created git repo on github.uiowa.edu and added the rest of the team members
* Added initial readme and directory for team member personal logs
* Added directory for docs that we'll have for the project

## 2/2/2017
* Moved files and directories from the original xWin repository to the one we're supposed to use.
* Met with team to flush out the epics that we are planning on completing

## 2/6/2017
* Reorganized useful links doc
* Added a bunch of links for C++ best practices and testing
* Researching how to best write a C++ app for Windows

## 2/7/2017
* Discussed test plan in scrum and how we're going to go about it
* Kyle and I started the test plan

## 2/8/2017
* Was sick, nothing got done unfortunately

## 2/9/2017
* Pulled project that dan made from the repository and got it to build
* Currently using a 3rd party library to interact with the controller, looking into switching to microsofts
* Updated gitignore to ignore executable files so there aren't massive commits
* Built and basic test of the current application

## 2/10/2017 - 2/12/2017
* Weekend

## 2/13/2017
* Got some listeners working a bit in the controller class
* Can detect left analog stick X and Y values
* Decided we're sticking with SharpDX
* Learned how to use NuGet to install packages
* Researched moving mouse pointer but it's harder than I thought it would be

## 2/14/2017
* Fighting with getting the code to compile
* Getting dlls needed for moving the mouse pointer
* Stack Overflow is a godsend

## 2/15/2017
* Got the code to compile!!
* Found a helpful stack overflow to getting the pointer to move mouse
* Found a video turorial to help
* leaning dllimports
* Started rewrite of the controller class

## 2/16/2017
* Still having trouble getting the mouse to move correctly. Getting nullptr errors
* Getting mouse cursor postion reletive to the screen and printing it out
* Got other listerners to print out for each of the other buttons
* Looked into testing for the controller and how to get that set up but haven't started it yet

## 2/17/2017
* Sat down and discussed how the controller class is actually going to comunicate with the rest of the project
  * Witch methods are going to be needed
  * how to translate the analog stick inputs to cursor movement
  * testing
* Short retrospective start for monday

## 2/18 - 2/19/2017
* Weekend

## 2/20/2017
* Team retrospective and presentation
* At scrum, showed off what the controller does currently 
  * can move the pointer
  * no nullptr errors
  * cant really see the pointer though, especiially when moving

## 2/21/2017
* Nada mass, playing around with the curseor and trying to get it to move predictably 

## 2/22/2017
* Got the cursor to move with the dpad
* Jake and I started to develope a method for moving the cursor witht he analog sticks easily
* Jake developed an algorithm for translating the mouse movement to the screen in a viewable instead of it bouncing aroun the screen too fast
* Alg needs more fine tuning

## 2/23/2017
* Got the mouse cursor moving with the analog sticks!!!
* Some issues debugging it but now it works as expected
* Some momentum can be seen but not too much. Need to fix
* Mouse movement is jittery and needs to be fixed.
  * WOuldn't be an issue w/ C++...
* Finally on to testing