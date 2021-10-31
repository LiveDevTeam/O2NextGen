#!/bin/bash

# docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=your@Password" -e "MSSQL_PID=sql" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest up
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=your@Password" \
   -p 1433:1433 --name sql1 -h sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2017-latest
