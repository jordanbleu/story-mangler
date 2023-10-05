#!/bin/bash

# build api to get new swaggerfile
cd ../../ManglerAPI
dotnet build

# Build ManglerAPI.CodeGen
cd ../utilities/ManglerAPI.CodeGen/
dotnet build

# Run process
cd ./bin/Debug/Net7.0
dotnet ManglerAPI.CodeGen.dll

# build whole solution
cd ../../../../..
dotnet build Mangler.sln