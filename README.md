# Open Access 5.3 Developer Note
If you need to send an email to communicate an error or bug you encounter, please send a screen shot, supporting code you are using, and the image used to create the error.

A simple C# sample application is provided with this release. There have been minor API changes, nearly all of which should be transparent to the existing codebase. One deployment change is the addition of several new DLLs (see the lib directory for the full list) which were added to support new camera models (TiX520, TiX560, TiX640, TiX660, TiX1000, TiS10, TiS20, TiS40, TiS45, TiS50, TiS55, TiS60, TiS65).

The C# sample application has been updated to use all of these new features and continues to include sample code demonstrating how to access the data contained in .IS3 files from Ti125-family cameras. (These are “movie” files and you now have the ability to get frame-by-frame infrared data.)

In the recent past, we changed the standard deployment to be unsigned DLLs (previous releases have been signed).
The public release of SmartView 4.3 is now available to customers and the Open Access library has benefitted greatly from the release testing.

Please note the terms of the Open Access license agreement (last updated December 2007) included with the release package.

Thank you for participating in our Open Access program!
