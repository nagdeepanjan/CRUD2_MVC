using Entities;

namespace ServiceContracts.DTO;

/// <summary>
///     Represents DTO class that is used as return type of most methods of Person service
/// </summary>
public class PersonResponse
{
    public Guid PersonId { get; set; }
    public string? PersonName { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public Guid? CountryId { get; set; }
    public string? Country { get; set; }
    public string? Address { get; set; }
    public bool ReceiveNewsLetters { get; set; }
    public double? Age { get; set; }

    /// <summary>
    ///     Compare the current object data with the parameter object
    /// </summary>
    /// <param name="obj">The PersonResponse Object</param>
    /// <returns>TRUE or FALSE, indicating whether all person details match</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if (obj.GetType() != typeof(PersonResponse)) return false;

        PersonResponse person = (PersonResponse)obj;
        return PersonId == person.PersonId && PersonName == person.PersonName && Email == person.Email &&
               DateOfBirth == person.DateOfBirth && Gender == person.Gender && CountryId == person.CountryId &&
               Address == person.Address && ReceiveNewsLetters == person.ReceiveNewsLetters;
    }

    public override string ToString()
    {
        return $"PersonID: {PersonId}, PersonName: {PersonName}, Email: {Email}, DateOfBirth: {DateOfBirth}";
    }
}

public static class PersonExtensions
{
    /// <summary>
    ///     An extension method to convert an object of Person class into PersonResponse class
    /// </summary>
    /// <param name="person">The Person object to convert</param>
    /// ///
    /// <returns>Returns the converted PersonResponse object</returns>
    public static PersonResponse ToPersonResponse(this Person person)
    {
        //person => convert => PersonResponse


        return new PersonResponse()
        {
            PersonId = person.PersonId,
            PersonName = person.PersonName,
            Email = person.Email,
            DateOfBirth = person.DateOfBirth,
            ReceiveNewsLetters = person.ReceiveNewsLetters,
            Address = person.Address,
            CountryId = person.CountryId,
            Gender = person.Gender,
            Age = person.DateOfBirth != null
                ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25)
                : null
        };
    }
}