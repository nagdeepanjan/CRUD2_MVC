using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries;

    public CountriesService()
    {
        _countries = new List<Country>();
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        //Validation: countryAddRequest parameter cannot be null
        if (countryAddRequest == null)
            throw new ArgumentNullException(nameof(countryAddRequest));

        //Validation: name of country should not be null
        if (countryAddRequest.CountryName == null)
            throw new ArgumentException(nameof(countryAddRequest.CountryName));

        //Validation: duplicates should not be allowed
        if (_countries.Any(c => countryAddRequest.CountryName.ToLower() == c.CountryName?.ToLower()))
            throw new ArgumentException("Country already exists");

        Country country = countryAddRequest.ToCountry();
        country.CountryId = Guid.NewGuid();

        _countries.Add(country);

        return country.ToCountryResponse();
    }

    public List<CountryResponse> GetAllCountries()
    {
        return _countries.Select(c => c.ToCountryResponse()).ToList();
    }

    public CountryResponse? GetCountryByCountryId(Guid? countryId)
    {
        if (countryId is null)
            return null;

        return _countries.FirstOrDefault(c => c.CountryId == countryId)?.ToCountryResponse();
    }
}