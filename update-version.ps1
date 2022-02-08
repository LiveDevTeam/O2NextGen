param ($branch )
write-host $system_build_counter 

# $branch = git rev-parse --abbrev-ref HEAD
Write-Host "##branch is: $branch"
$versionTag = $(git describe --match "*.*" --abbrev=0)
Write-Host "##versionTag is: $versionTag"
$distanceFromTag = $(git rev-list "$versionTag..HEAD" --count)
Write-Host "##distanceFromTag is: $distanceFromTag"

$splitted = $versionTag.Split(".")
$revision = [int]$distanceFromTag;

# Sometimes the branch will be a full path, e.g., 'refs/heads/master'.
# If so we'll base our logic just on the last part.
if ($branch.Contains("/")) {
   $branch = $branch.substring($branch.lastIndexOf("/")).trim("/")
}

if ($splitted.Length -eq 4) {
   $revision += [int]$splitted[3]
}
if ($branch -eq "master") {
   $versionInfo = -join ($splitted[0], ".", $splitted[1], ".", $splitted[2], ".", $revision)
}
elseif ($branch -eq "develop") {
   $versionInfo = -join ($splitted[0], ".", $splitted[1], ".", $splitted[2], "-", "dev", ".", $revision)
}

elseif ($branch -match "release-.*") {
   $versionInfo = -join ($splitted[0], ".", $splitted[1], ".", $splitted[2], ".", $revision)
}
else {
   # If the branch starts with "feature-", just use the feature name
   $branch = $branch.replace("feature-", "")
   $versionInfo = -join ($splitted[0], ".", $splitted[1], ".", $splitted[2], "-", $branch, ".", $revision)
}
$version = -join ($splitted[0], ".", $splitted[1], ".", $splitted[2], ".", $revision)
Write-Host "##Version is: $version"
Write-Host "##VersionInfo is: $versionInfo"

$dockerTag = -join ($branch, "-", $splitted[0], ".", $splitted[1], ".", $splitted[2], ".", $revision)
Write-Host "##Docker tag is: $dockerTag"

$versionInfo | Out-File ./version.txt
$dockerTag | Out-File ./tag.txt