param (
    [string]$path1
)
 #Write-Host  $path1
# Path to the AssemblyInfo.cs file
$assemblyInfoPath = $path1 +"Properties\AssemblyInfo.cs"
#Write-Host "AssemblyInfo.cs path: $assemblyInfoPath"

# Read the content of the AssemblyInfo.cs file
$assemblyInfoContent = Get-Content $assemblyInfoPath -Raw

# Regular expression pattern to match the AssemblyVersion attribute
$pattern = '\[assembly: AssemblyVersion\("(\d+)\.(\d+)\.(\d+)\.(\d+)"\)\]'

# Find the AssemblyVersion attribute in the content using Select-String
$match = $assemblyInfoContent | Select-String -Pattern $pattern

if ($match) {
    $currentVersion = $match.Matches[0].Value
    $majorVersion = $match.Matches[0].Groups[1].Value
    $minorVersion = $match.Matches[0].Groups[2].Value
    $buildNumber = [int]$match.Matches[0].Groups[3].Value
    $revisionNumber = [int]$match.Matches[0].Groups[4].Value

    # Increment the revision number
    $revisionNumber++
    
    # Check if the revision number exceeds 200
    if ($revisionNumber -gt 200) {
        # Increment the build number and reset the revision number to 1
        $buildNumber++
        $revisionNumber = 1
    }

 #   Write-Host "Current Version: $currentVersion"
  #  Write-Host "New version: $majorVersion.$minorVersion.$buildNumber.$revisionNumber"

    # Update the AssemblyVersion in the content
    $newVersion = $currentVersion -replace $pattern, "`[assembly: AssemblyVersion(`"$majorVersion.$minorVersion.$buildNumber.$revisionNumber`")`]"
    $updatedContent = $assemblyInfoContent -replace [regex]::Escape($currentVersion), $newVersion
    Write-Host "New Version: $newVersion"
  #  Write-Host "Content: $updatedContent"

    # Save the updated content back to the AssemblyInfo.cs file
    $updatedContent | Set-Content $assemblyInfoPath
} else {
    Write-Host "Error: Failed to find AssemblyVersion attribute in AssemblyInfo.cs"
}