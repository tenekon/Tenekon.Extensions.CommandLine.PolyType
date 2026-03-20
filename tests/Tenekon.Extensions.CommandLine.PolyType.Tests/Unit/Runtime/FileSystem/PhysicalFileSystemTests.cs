using Shouldly;
using Tenekon.Extensions.CommandLine.PolyType.Runtime.FileSystem;
using Tenekon.Extensions.CommandLine.PolyType.Tests.Fixtures;

namespace Tenekon.Extensions.CommandLine.PolyType.Tests.Runtime.FileSystem;

public class PhysicalFileSystemTests
{
    [Fact]
    public void FileExists_ReturnsTrueForExistingFile()
    {
        using var fs = new TempFsFixture();
        var file = fs.CreateFile();
        var fileSystem = new PhysicalFileSystem();

        fileSystem.File.FileExists(file).ShouldBeTrue();
    }

    [Fact]
    public void DirectoryExists_ReturnsTrueForExistingDirectory()
    {
        using var fs = new TempFsFixture();
        var dir = fs.CreateDirectory();
        var fileSystem = new PhysicalFileSystem();

        fileSystem.Directory.DirectoryExists(dir).ShouldBeTrue();
    }

    [Fact]
    public void Path_InvalidChars_AreNotEmpty()
    {
        var fileSystem = new PhysicalFileSystem();

        fileSystem.Path.GetInvalidPathChars().Length.ShouldBeGreaterThan(expected: 0);
        fileSystem.Path.GetInvalidFileNameChars().Length.ShouldBeGreaterThan(expected: 0);
    }
}