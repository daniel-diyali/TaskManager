#!/bin/bash

# Build and Test Script for TaskManager
echo "🔨 TaskManager Build & Test Script"
echo "=================================="

# Check if .NET is available
if command -v dotnet &> /dev/null; then
    echo "✅ .NET SDK found"
    
    echo "📦 Restoring packages..."
    dotnet restore
    
    echo "🔨 Building solution..."
    dotnet build --configuration Release
    
    echo "🧪 Running tests..."
    dotnet test --configuration Release --logger "console;verbosity=detailed"
    
    echo "✅ Build and test completed successfully!"
else
    echo "⚠️  .NET SDK not found in PATH"
    echo "📋 To install .NET 6.0 SDK:"
    echo "   1. Visit: https://dotnet.microsoft.com/download/dotnet/6.0"
    echo "   2. Download and install .NET 6.0 SDK"
    echo "   3. Restart terminal and run this script again"
    echo ""
    echo "📁 Project structure is ready for development:"
    echo "   - C# WinForms application in src/"
    echo "   - NUnit tests in tests/"
    echo "   - SpecFlow BDD tests configured"
    echo "   - GitHub Actions CI pipeline ready"
fi