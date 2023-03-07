using EdataProject.Domain.Validation;
using static System.Net.Mime.MediaTypeNames;

namespace EdataProject.Domain.Entities;

public sealed class Client : Entity
{
    public string? Name { get; private set; }
    public string? LastName { get; private set; }
    public string? Cpf { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string? Email { get; private set; }

    public Client(string? name, string? lastName, string? cpf, DateTime birthDate, string? email)
    {
        ValidateDomain(name, lastName, cpf, birthDate, email);
    }

    public Client(int id, string? name, string? lastName, string? cpf, DateTime birthDate, string? email)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name, lastName, cpf, birthDate, email);
    }

    public void Update(string? name, string? lastName, string? cpf, DateTime birthDate, string? email)
    {
        ValidateDomain(name, lastName, cpf, birthDate, email);
    }

    private void ValidateDomain(string? name, string? lastName, string? cpf, DateTime birthDate, string? email)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name. Name is required");

        DomainExceptionValidation.When(name?.Length < 4,
            "Invalid name, too short, minimum 4 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(lastName),
            "Invalid last name. Last Name is required");

        DomainExceptionValidation.When(cpf?.Length < 11, "Invalid CPF value");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "Invalid email. Email is required");

        Name = name;
        LastName = lastName;
        Cpf = cpf;
        BirthDate = birthDate;
        Email = email;

    }
}
