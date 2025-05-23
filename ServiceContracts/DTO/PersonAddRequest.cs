﻿using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO;

/// <summary>
///     Acts as a DTO for inserting a new person
/// </summary>
public class PersonAddRequest
{
    //[Required(ErrorMessage = "Person Name cannot be black")]
    public string? PersonName { get; set; }


    //[Required(ErrorMessage = "Email cannot be blank")]
    //[EmailAddress(ErrorMessage = "Invalid Email")]
    //[DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    //[DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }


    public GenderOptions? Gender { get; set; }


    public Guid? CountryId { get; set; }


    public string? Address { get; set; }


    public bool ReceiveNewsLetters { get; set; }

    /// <summary>
    ///     Converts the current object of PersonAddRequest into a new object of Person type
    /// </summary>
    /// <returns></returns>
    public Person ToPerson()
    {
        return new Person()
        {
            PersonName = PersonName,
            Email = Email,
            DateOfBirth = DateOfBirth,
            Gender = Gender.ToString(),
            Address = Address,
            CountryId = CountryId,
            ReceiveNewsLetters = ReceiveNewsLetters
        };
    }
}