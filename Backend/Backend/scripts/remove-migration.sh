#!/bin/bash
cd src/Backend.Infrastructure
echo "Running 'dotnet ef migrations remove --force' command..."
dotnet ef migrations remove --force