#addin nuget:?package=Cake.FileHelpers&version=5.0.0

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");


//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////

var solutionFile = File("./Epam.ExternalTraining.sln");
var testsDir  = Directory("./test");
var testResultsDir = testsDir + Directory("TestResults");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    DotNetClean(solutionFile, new DotNetCleanSettings
    {
        Configuration = configuration
    });
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetBuild(solutionFile, new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetTest(solutionFile, new DotNetCoreTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
        Loggers = new[] {"trx"},
        ResultsDirectory = testResultsDir,
        Verbosity = DotNetVerbosity.Minimal
    });
});

Task("TestAndPrintResults")
    .IsDependentOn("Test")
    .Does(() => {
        Warning("This isn't implemented yet"); // TODO: output something sensible
        // Information(FileReadText(File()));
    });


//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);