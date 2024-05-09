#!/bin/bash

# Run dotnet test with Chrome environment in the background
dotnet test --environment "browser=chrome" &

# Run dotnet test with Firefox environment in the background
dotnet test --environment "browser=firefox" &

dotnet test --environment "browser=android" &


# Wait for all background jobs to finish
wait
