# ビルドを実行してnugetに公開するスクリプトです

#############################################################
# ここの設定を変更してください
#############################################################
$SolutionFolder = "src"
$NugetSource  = "nuget.org" 
#############################################################

# Build Solution
dotnet build $SolutionFolder  --configuration release

# Pack Nuget Packages
dotnet pack $SolutionFolder  --configuration release

# Publish nupkg Files
# ソリューションフォルダにあるすべてのnupkgをpublishします
$nugetFiles = Get-ChildItem -Path $SolutionFolder -Recurse -File -Include *.nupkg 

foreach ( $file in $nugetFiles)
{
    $fullPath = $file.FullName

    # テスト関連のフォルダは対象外
    if ( $fullPath.Contains("TestData") -or $fullPath.Contains("Tests")) {
        continue
    }

    # Message
    $message = "# Publishing Nuget Package to " + $NugetSource + " : " + $fullPath
    Write-Output ""
    Write-Output ""
    Write-Output $message

    # nugetに公開
    if ( $NugetSource -eq "nuget.org")
    {
        dotnet nuget push $fullPath --source "https://api.nuget.org/v3/index.json" --skip-duplicate

    } else {
        dotnet nuget push $fullPath --source $NugetSource --skip-duplicate
    }
}

Write-Output ""
Write-Output ""
Write-Output "Finished"
