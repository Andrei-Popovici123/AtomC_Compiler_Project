#This file is meant to run the compiler in vscode it will have to be manualy added to the project directory where the c/atomc file resides

# Path to the built compiler DLL 
$compilerDll = "C:\Users\crist\RiderProjects\AtomC_Compiler_Project\AtomC_Compiler_Project.CLI\bin\Release\net9.0\AtomC_Compiler_Project.CLI.dll"

# Run using the dotnet runtime
dotnet $compilerDll
# use command:
# .\run-compiler.ps1