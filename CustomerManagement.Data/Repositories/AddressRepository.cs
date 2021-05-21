using System;
using System.Threading.Tasks;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Data.Sql;

namespace CustomerManagement.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ISqlOrm _sqlOrm;
        public AddressRepository(ISqlOrm sqlOrm)
        {
            _sqlOrm = sqlOrm;
        }

        public async Task<Address> GetAsync(int id)
        {
            var address = await _sqlOrm.QueryAsync<Address>(SelectSql.Address, id);

            if (address != null)
            { 
                address.City = await _sqlOrm.QueryAsync<City>(SelectSql.City, address.CityId);
            }

            if (address?.City != null)
            {
                address.City.Country = await _sqlOrm.QueryAsync<Country>(SelectSql.Country, address.City.CountryId);
            }
            return address;
        }

        public async Task<int> CreateAsync(Address newAddress)
        {
            newAddress.City.Country.CreatedDate = DateTime.UtcNow;
            newAddress.City.Country.LastUpdated = DateTime.UtcNow;
            var countryId = await _sqlOrm.CreateEntityAsync(CreateSql.Country, newAddress.City.Country);

            newAddress.City.CountryId = countryId;
            newAddress.City.CreatedDate = DateTime.UtcNow;
            newAddress.City.LastUpdated = DateTime.UtcNow;
            var cityId = await _sqlOrm.CreateEntityAsync(CreateSql.City, newAddress.City);

            newAddress.CityId = cityId;
            newAddress.CreatedDate = DateTime.UtcNow;
            newAddress.LastUpdated = DateTime.UtcNow;
            return await _sqlOrm.CreateEntityAsync(CreateSql.Address, newAddress);
        }

        public async Task<int> UpdateAsync(Address address)
        {
            var rowsChanged = 0;

            if (address?.City?.Country != null)
            {
                address.City.Country.LastUpdated = DateTime.UtcNow;
                await _sqlOrm.ExecuteAsync(UpdateSql.Country, address.City.Country);
                rowsChanged++;
            }

            if (address?.City != null)
            {
                address.City.CountryId = address.City.Country.Id;
                address.City.LastUpdated = DateTime.UtcNow;
                await _sqlOrm.ExecuteAsync(UpdateSql.City, address.City);
                rowsChanged++;
            }
            
            if (address != null)
            {
                address.CityId = address.City.Id;
                address.LastUpdated = DateTime.UtcNow;
                await _sqlOrm.ExecuteAsync(UpdateSql.Address, address);
                rowsChanged++;
            }

            return rowsChanged;
        }
    }
}
