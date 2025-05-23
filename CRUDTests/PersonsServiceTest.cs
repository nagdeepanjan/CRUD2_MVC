﻿namespace CRUDTests;

using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
using Xunit;

public class PersonsServiceTest
{
    //private fields
    private readonly ICountriesService _countriesService;
    private readonly IPersonsService _personsService;

    public PersonsServiceTest()
    {
        _personsService = new PersonsService();
        _countriesService = new CountriesService();
    }

    #region AddPerson

    //When we supply null value as PersonAddRequest, it should throw ArgumentNullException
    [Fact]
    public void AddPerson_NullPerson()
    {
        //Arrange
        PersonAddRequest? personAddRequest = null;

        //Assert
        Assert.Throws<ArgumentNullException>(
            //Act
            () => { _personsService.AddPerson(personAddRequest); });
    }

    [Fact]
    public void AddPerson_PersonNameIsNull()
    {
        //Arrange
        PersonAddRequest? personAddRequest = new PersonAddRequest { PersonName = null };

        //Assert
        Assert.Throws<ArgumentException>(
            //Act
            () => { _personsService.AddPerson(personAddRequest); });
    }

    //When we supply proper person details, it should insert the person into the persons list; and it should return an object of PersonResponse, which includes with the newly generated person id
    [Fact]
    public void AddPerson_ProperPersonDetails()
    {
        //Arrange
        PersonAddRequest? personAddRequest = new PersonAddRequest()
        {
            PersonName = "Person name...",
            Email = "person@example.com",
            Address = "sample address",
            CountryId = Guid.NewGuid(),
            Gender = GenderOptions.Male,
            DateOfBirth = DateTime.Parse("2000-01-01"),
            ReceiveNewsLetters = true
        };

        //Act
        PersonResponse person_response_from_add = _personsService.AddPerson(personAddRequest);

        List<PersonResponse> persons_list = _personsService.GetAllPersons();

        //Assert
        Assert.True(person_response_from_add.PersonId != Guid.Empty);

        Assert.Contains(person_response_from_add, persons_list);
    }

    #endregion
}