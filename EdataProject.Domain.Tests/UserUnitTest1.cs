using EdataProject.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace EdataProject.Domain.Tests;

public class UserUnitTest1
{
    [Fact]
    public void CreateUser_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Client(1, "Gustavo", "Andrade", "49080960829",
            new DateTime(2000, 9, 17), "gustavo@teste.com");
        action.Should()
            .NotThrow<EdataProject.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateUser_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Client(-1, "Gustavo", "Andrade", "49080960829",
            new DateTime(2000, 9, 17), "gustavo@teste.com");

        action.Should().Throw<EdataProject.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateUser_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Client(1, "Gus", "Andrade", "49080960829", new DateTime(2000, 9, 17),
             "gustavo@teste.com");
        action.Should().Throw<EdataProject.Domain.Validation.DomainExceptionValidation>()
             .WithMessage("Invalid name, too short, minimum 4 characters");
    }

    [Fact]
    public void CreateUser_ShortCpfValue_DomainExceptionShortName()
    {
        Action action = () => new Client(1, "Gustavo", "Andrade", "490809", new DateTime(2000, 9, 17),
             "gustavo@teste.com");
        action.Should().Throw<EdataProject.Domain.Validation.DomainExceptionValidation>()
             .WithMessage("Invalid CPF value");
    }

    [Fact]
    public void CreateProduct_WithNullEmail_NoDomainException()
    {
        Action action = () => new Client(1, "Gustavo", "Andrade", "49080960829",
            new DateTime(2000, 9, 17), null);
        action.Should().NotThrow<EdataProject.Domain.Validation.DomainExceptionValidation>();
    }

}
