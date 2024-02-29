#!/bin/sh
#
# This script has commands to a) build and b) execute my dotnet console app
#
FIRSTARG="$1"

if [ "$FIRSTARG" = "-b" ] ; then
    dotnet build --output ./build_output
else
    dotnet ./build_output/TheRepeatingStream.dll
fi
