using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class PersonsService : IPersonsService
{
    private readonly ICountriesService _countriesService; //This field is needed by Person as a dependency
    private readonly List<Person> _persons;

    public PersonsService()
    {
        _countriesService = new CountriesService();
        _persons = new List<Person>();
    }

    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
        //check if PersonAddRequest is not null
        if (personAddRequest == null) throw new ArgumentNullException(nameof(personAddRequest));

        //Validate PersonName
        if (string.IsNullOrEmpty(personAddRequest.PersonName))
            throw new ArgumentException("Person name is empty");

        //convert personAddRequest into Person type
        Person person = personAddRequest.ToPerson();

        //generate PersonID
        person.PersonId = Guid.NewGuid();

        _persons.Add(person);

        return ConvertPersonToPersonResponse(person);
    }

    public List<PersonResponse> GetAllPersons()
    {
        throw new NotImplementedException();
    }

    private PersonResponse ConvertPersonToPersonResponse(Person person)
    {
        PersonResponse personResponse = person.ToPersonResponse();
        personResponse.Country = _countriesService.GetCountryByCountryId(person.CountryId)?.CountryName;

        return personResponse;
    }
}