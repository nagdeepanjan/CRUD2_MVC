using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
///     Represents business logic for manipulating Person entity
/// </summary>
public interface IPersonsService
{
    /// <summary>
    ///     Adds a person into an existing list of persons
    /// </summary>
    /// <param name="personAddRequest">Person to add</param>
    /// <returns>Returns the same person's details, along with the newly generated PersonID</returns>
    PersonResponse AddPerson(PersonAddRequest? personAddRequest);

    /// <summary>
    ///     Returns all persons
    /// </summary>
    /// <returns>Returns a list of PersonResponse objects</returns>
    List<PersonResponse> GetAllPersons();
}