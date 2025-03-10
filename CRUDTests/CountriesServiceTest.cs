using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace CRUDTests;

public class CountriesServiceTest
{
    private readonly ICountriesService _countriesService;


    public CountriesServiceTest()
    {
        _countriesService = new CountriesService();
    }

    #region GetCountryByCountryId

    [Fact]
    public void GetCountryByCountryId_NullCountryId()
    {
        //Arrange
        Guid? countryId = null;

        //Act
        CountryResponse? country_response_from_method = _countriesService.GetCountryByCountryId(countryId);

        //Assert
        Assert.Null(country_response_from_method);
    }

    [Fact]
    //If we supply a valid countryId, it should return the matching country as CountryResponse
    public void GetCountryByCountryID_ValidCountryId()
    {
        //Arrange
        CountryAddRequest country_add_request = new CountryAddRequest { CountryName = "Japan" };
        CountryResponse country_response_from_add = _countriesService.AddCountry(country_add_request);

        //Act
        CountryResponse? country_response_from_get =
            _countriesService.GetCountryByCountryId(country_response_from_add.CountryId);

        //Assert
        Assert.Equal(country_response_from_get, country_response_from_add);
    }

    #endregion

    #region GetAllCountries

    [Fact]
    //List of countries should be empty by default
    public void GetAllCountries_EmptyList()
    {
        //Arrange

        //Act
        List<CountryResponse> countries = _countriesService.GetAllCountries();

        //Assert
        Assert.Empty(countries);
    }

    [Fact]
    public void GetAllCountries_AddSomeCountries()
    {
        //Arrange
        List<CountryResponse> countries_list_from_add_country = new();
        List<CountryAddRequest> country_request_list = new()
        {
            new CountryAddRequest { CountryName = "USA" }, new CountryAddRequest { CountryName = "India" },
            new CountryAddRequest { CountryName = "Canada" }
        };

        //Act
        country_request_list.ForEach(c => countries_list_from_add_country.Add(_countriesService.AddCountry(c)));
        List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries();

        //Assert
        countries_list_from_add_country.ForEach(c => Assert.Contains(c, actualCountryResponseList));
    }

    #endregion

    #region AddCountry

    //When CountryAddRequest is null, it should throw ArgumentNullException
    [Fact]
    public void AddCountry_NullCountry()
    {
        //Arrange
        CountryAddRequest? request = null;

        //Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            //Act
            _countriesService.AddCountry(request);
        });
    }

    //When CountryName is null, it should throw ArgumentException
    [Fact]
    public void AddCountry_CountryNameIsNull()
    {
        //Arrange
        CountryAddRequest? request = new CountryAddRequest { CountryName = null };

        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            //Act
            _countriesService.AddCountry(request);
        });
    }

    //When CountryName is duplicate, it should throw ArgumentException
    [Fact]
    public void AddCountry_DuplicateCountryName()
    {
        //Arrange
        CountryAddRequest? request = new CountryAddRequest { CountryName = "Nepal" };
        CountryAddRequest? request2 = new CountryAddRequest { CountryName = "Nepal" };

        _countriesService.AddCountry(request);

        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            //Act
            _countriesService.AddCountry(request);
            _countriesService.AddCountry(request2);
        });
    }

    //When you supply proper CountryName, it should insert the country in the existing list of countries
    [Fact]
    public void AddCountry_OK()
    {
        //Arrange
        CountryAddRequest? request = new CountryAddRequest { CountryName = "Germany" };

        //Act
        CountryResponse response = _countriesService.AddCountry(request);
        List<CountryResponse> countries_from_GetAllCountries = _countriesService.GetAllCountries();

        //Assert
        Assert.True(response.CountryId != Guid.Empty);
        Assert.Contains(response, countries_from_GetAllCountries);
    }

    #endregion
}