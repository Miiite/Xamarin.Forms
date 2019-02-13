#!/bin/bash

# Turn off automatic package restore on Visual Studio before running this script
# Visual Studio => Preferences => Nuget => General => uncheck the Package Restore box
# Needing to turn restore off isn't necessary in the latest preview releases of VS Mac

# NuGet restore
msbuild /t:restore Xamarin.forms.sln

# Build XF build tasks
msbuild Xamarin.Forms.Build.Tasks/Xamarin.Forms.Build.Tasks.csproj

# ensure resources are all in sync otherwise first run might cause a Resource ID not found error
msbuild Xamarin.Forms.ControlGallery.Android/Xamarin.Forms.ControlGallery.Android.csproj /t:rebuild

# open in vsmac and should be able to build/run from here
open Xamarin.Forms.sln
