using System;
using System.Collections.Generic;
using System.Text;
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
            var address = await _sqlOrm.QueryAsync<Address>(SelectSql.Address, "address", id);
            address.City = await _sqlOrm.QueryAsync<City>(SelectSql.City, "city", address.CityId);
            address.City.Country = await _sqlOrm.QueryAsync<Country>(SelectSql.Country, "country", address.City.CountryId);
            return address;
        }

        public async Task<int> CreateAsync(Address newAddress)
        {
            newAddress.City.Country.CreateDate = DateTime.UtcNow;
            newAddress.City.Country.LastUpdate = DateTime.UtcNow;
            var countryId = await _sqlOrm.CreateEntityAsync("country", CreateSql.Country, newAddress.City.Country, newAddress.City.Country);

            var cityId = await _sqlOrm.CreateEntityAsync("city", CreateSql.City, newAddress.City, new 
            {
                newAddress.City.Name,
                CountryId = countryId,
                CreateDate = DateTime.UtcNow,
                newAddress.City.CreatedBy,
                LastUpdate = DateTime.UtcNow,
                newAddress.City.LastUpdateBy
            });

            return await _sqlOrm.CreateEntityAsync("address", CreateSql.Address, newAddress, new
            {
                newAddress.Address1,
                newAddress.Address2,
                CityId = cityId,
                newAddress.PostalCode,
                newAddress.Phone,
                CreateDate = DateTime.UtcNow,
                newAddress.CreatedBy,
                LastUpdate = DateTime.UtcNow,
                newAddress.LastUpdateBy
            });
        }

        public async Task<int> UpdateAsync(Address address)
        {
            var rowsChanged = 0;

            if (address?.City?.Country != null)
            {
                address.City.Country.LastUpdate = DateTime.UtcNow;
                rowsChanged += await _sqlOrm.ExecuteAsync(UpdateSql.Country, address?.City?.Country);
            }

            if (address?.City != null)
            {
                rowsChanged += await _sqlOrm.ExecuteAsync(UpdateSql.City, new
                {
                    address.City.Name,
                    CountryId = address.City.Country.Id,
                    LastUpdate = DateTime.UtcNow,
                    address.City.LastUpdateBy
                });
            }
            
            if (address != null)
            {
                rowsChanged += await _sqlOrm.ExecuteAsync(UpdateSql.Address, new
                {
                    address.Address1,
                    address.Address2,
                    CityId = address.City.Id,
                    address.PostalCode,
                    address.Phone,
                    LastUpdate = DateTime.UtcNow,
                    address.LastUpdateBy
                });
            }

            return rowsChanged;
        }
    }
}
