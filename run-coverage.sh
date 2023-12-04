dotnet test Test/Test.csproj  /p:CollectCoverage=true --collect:"XPlat Code Coverage"
mkdir coverage
mv Test/TestResults/*/*.cobertura.xml coverage