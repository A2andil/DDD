#!/bin/bash
cd src/A5bark.Infrastructure
echo "Running 'dotnet ef migrations remove --force' command..."
dotnet ef migrations remove --force