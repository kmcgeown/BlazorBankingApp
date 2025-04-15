using FluentAssertions;

namespace ArchitectureTests;

/// <summary>
/// Check that Clean Architecture is enforced
/// </summary>
public class ArchitectureTests
{
    private const string DomainNameSpace = "Domain";
    private const string ApplicationNameSpace = "Application";
    private const string InfrastructureNameSpace = "Infrastructure";
    private const string WebNameSpace = "Web";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProject()
    {
        var assemblyReference = typeof(Domain.DomainAssembly).Assembly.GetReferencedAssemblies();
        var otherProjects = new[] { ApplicationNameSpace, InfrastructureNameSpace, WebNameSpace };

        //Act
        var testResult = assemblyReference.Any(reference => otherProjects.Contains(reference.Name));

        //Assert
        testResult.Should().BeFalse();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProject()
    {
        var assemblyReference =
            typeof(Infrastructure.InfrastructureAssembly).Assembly.GetReferencedAssemblies();
        var otherProjects = new[] { InfrastructureNameSpace, WebNameSpace };

        //Act
        var testResult = assemblyReference.Any(reference => otherProjects.Contains(reference.Name));

        //Assert
        testResult.Should().BeFalse();
    }

    [Fact]
    public void Web_Should_Not_HaveDependencyOnOtherProject()
    {
        var assemblyReference =
            typeof(Infrastructure.InfrastructureAssembly).Assembly.GetReferencedAssemblies();
        var otherProjects = new[] { InfrastructureNameSpace, DomainNameSpace, WebNameSpace };

        //Act
        var testResult = assemblyReference.Any(reference => otherProjects.Contains(reference.Name));

        //Assert
        testResult.Should().BeFalse();
    }
}
