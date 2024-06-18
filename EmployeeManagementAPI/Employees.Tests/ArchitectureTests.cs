using NetArchTest.Rules;
using Xunit;

namespace Employees.Tests
{
    public class ArchitectureTests
    {
        private const string EmployeesApiAssembly = "Employees.API";
        private const string EmployeesApplicationAssembly = "Employees.Application";
        private const string EmployeesDomainAssembly = "Employees.Domain";
        private const string EmployeesInfrastructureAssembly = "Employees.Infrastructure";
        private const string EmployeesContractsAssembly = "Employees.Contracts";


        [Fact]
        public void Employees_Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var domainAssembly = typeof(Domain.AssemblyReference).Assembly;
            var otherProjectsInSolution = new[]
            {
                EmployeesApiAssembly,
                EmployeesApplicationAssembly,
                EmployeesInfrastructureAssembly
            };

            // Act
            var testResult = Types.InAssembly(domainAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsInSolution)
                .GetResult();

            // Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Employees_Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var infrastructureAssembly = typeof(Infrastructure.AssemblyReference).Assembly;
            var otherProjectsInSolution = new[]
            {
                EmployeesApiAssembly,
                EmployeesApplicationAssembly,
                EmployeesDomainAssembly
            };

            // Act
            var testResult = Types.InAssembly(infrastructureAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsInSolution)
                .GetResult();

            // Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Employees_Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
            var otherProjectsInSolution = new[]
            {
                EmployeesApiAssembly,
                EmployeesInfrastructureAssembly
            };

            // Act
            var testResult = Types.InAssembly(applicationAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsInSolution)
                .GetResult();

            // Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Employees_API_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var apiAssembly = typeof(API.AssemblyReference).Assembly;
            var otherProjectsInSolution = new[]
            {
                EmployeesDomainAssembly
            };

            // Act
            var testResult = Types.InAssembly(apiAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsInSolution)
                .GetResult();

            // Assert
            Assert.True(testResult.IsSuccessful);
        }
    
        
        [Fact]
        public void Employees_Contracts_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var contractsAssembly = typeof(Contracts.AssemblyReference).Assembly;
            var otherProjectsInSolution = new[]
            {
                EmployeesApiAssembly,
                EmployeesApplicationAssembly,
                EmployeesDomainAssembly,
                EmployeesInfrastructureAssembly
            };

            // Act
            var testResult = Types.InAssembly(contractsAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsInSolution)
                .GetResult();

            // Assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}
