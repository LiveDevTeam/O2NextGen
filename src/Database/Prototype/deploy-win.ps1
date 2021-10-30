# DeployRelease.ps1
# Autor: Denis Prokhorchik
# Date: 20.11.2021
# Version: 0.1

param([string]$dbname)

if($dbname -eq $null)
Write-Host "Write dbname" -ForegroundColor Red
    break
}

Write-Host " -> scripts is started" -ForegroundColor Yellow
Write-Host " ==================== Setup ====================="
Write-Host "|                                                |"
Write-Host " ================== Setup END ==================="
write-Host ""
Write-Host " -> scripts is finished" -ForegroundColor Yellow