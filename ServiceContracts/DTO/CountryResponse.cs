﻿using Entities;

namespace ServiceContracts.DTO;

/// <summary>
///     DTO class that is used as a return type for most of CountriesService methods
/// </summary>
public class CountryResponse
{
    public Guid CountryId { get; set; }
    public string? CountryName { get; set; }

    public override bool Equals(object? obj) //Needed for the test cases
    {
        if (obj == null)
            return false;
        if (obj.GetType() != typeof(CountryResponse)) return false;
        return CountryId == ((CountryResponse)obj).CountryId && CountryName == ((CountryResponse)obj).CountryName;
    }
}

public static class CountryExtensions
{
    public static CountryResponse ToCountryResponse(this Country country)
    {
        return new CountryResponse { CountryId = country.CountryId, CountryName = country.CountryName };
    }
}