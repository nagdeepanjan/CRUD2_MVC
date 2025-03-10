using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
///     Represents business logic for manipulating Country entity
/// </summary>
public interface ICountriesService
{
    /// <summary>
    ///     Adds a country object to the list of countries
    /// </summary>
    /// <param name="countryAddRequest">Country object to be added</param>
    /// <returns>Returns the country object after adding it</returns>
    CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

    /// <summary>
    ///     Returns all countries from the list
    /// </summary>
    /// <returns>All countries as List of CountryResponse</returns>
    List<CountryResponse> GetAllCountries();

    /// <summary>
    ///     Returns a country object based on countryId
    /// </summary>
    /// <param name="countryId">CountryId (guid) to search</param>
    /// <returns>Matching country as CountryResponse object</returns>
    CountryResponse? GetCountryByCountryId(Guid? countryId);
}