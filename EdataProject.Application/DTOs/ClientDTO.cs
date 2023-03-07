using EdataProject.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EdataProject.Application.DTOs;

public class ClientDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Last Name is Required")]
    [MaxLength(200)]
    [DisplayName("Last Name")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "The CPF is Required")]
    [MinLength(11)]
    [MaxLength(14)]
    [DisplayName("CPF")]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = "The Birth Date is Required")]
    [DisplayName("Birth Date")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "The Email is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Email")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
}
