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

            if (address != null)
            { 
                address.City = await _sqlOrm.QueryAsync<City>(SelectSql.City, "city", address.CityId);
            }

            if (address?.City != null)
            {
                address.City.Country = await _sqlOrm.QueryAsync<Country>(SelectSql.Country, "country", address.City.CountryId);
            }
            return address;
        }

        public async Task<int> CreateAsync(Address newAddress)
        {
            newAddress.City.Country.CreateDate = DateTime.UtcNow;
            newAddress.City.Country.LastUpdate = DateTime.UtcNow;
            var countryId = await _sqlOrm.CreateEntityAsync(CreateSql.Country, newAddress.City.Country);

            var cityId = await _sqlOrm.CreateEntityAsync(CreateSql.City, new 
            {
                newAddress.City.Name,
                CountryId = countryId,
                CreateDate = DateTime.UtcNow,
                newAddress.City.CreatedBy,
                LastUpdate = DateTime.UtcNow,
                newAddress.City.LastUpdateBy
            });

            return await _sqlOrm.CreateEntityAsync(CreateSql.Address, new
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
                await _sqlOrm.ExecuteAsync(UpdateSql.Country, address?.City?.Country);
                rowsChanged++;
            }

            if (address?.City != null)
            {
                await _sqlOrm.ExecuteAsync(UpdateSql.City, new
                {
                    address.City.Id,
                    address.City.Name,
                    CountryId = address.City.Country.Id,
                    LastUpdate = DateTime.UtcNow,
                    address.City.LastUpdateBy
                });
                rowsChanged++;
            }
            
            if (address != null)
            {
                await _sqlOrm.ExecuteAsync(UpdateSql.Address, new
                {
                    address.Id,
                    address.Address1,
                    address.Address2,
                    CityId = address.City.Id,
                    address.PostalCode,
                    address.Phone,
                    LastUpdate = DateTime.UtcNow,
                    address.LastUpdateBy
                });
                rowsChanged++;
            }

            return rowsChanged;
        }
    }
}
