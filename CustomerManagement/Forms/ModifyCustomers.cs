using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using CustomerManagement.Translations;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms.Customers
{
    public partial class ModifyCustomer : Form
    {
        private readonly ICustomerRepository _customerRepository;
        private Customer _customer;
        private readonly User _currentUser;
        private readonly Translator _translator;

        public ModifyCustomer(User currentUser, Translator translator, ICustomerRepository customerRepository, int? customerId = null)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _translator = translator;
            _customerRepository = customerRepository;
            Init(customerId);
        }

        private void Init(int? customerId = null)
        {
            if (customerId != null)
            {
                _customer = _customerRepository.GetAsync((int)customerId).Result;

                nameInput.Text = _customer.Name;
                address1Input.Text = _customer.Address?.Address1;
                address2Input.Text = _customer.Address?.Address2;
                postalCodeInput.Text = _customer.Address?.PostalCode;
                phoneInput.Text = _customer.Address?.Phone;
                cityInput.Text = _customer.Address?.City?.Name;
                countryInput.Text = _customer.Address?.City?.Country?.Name;
                activeCheckbox.Checked = _customer.Active == 1;
            }
            TranslatePage();
        }

        private void TranslatePage()
        {
            if (_customer != null)
            {
                Name = _translator.Translate("customer.editCustomer");
                Text = _translator.Translate("customer.editCustomer");
                pageTitle.Text = _translator.Translate("customer.editCustomer");
            } 
            else
            {
                Name = _translator.Translate("customer.addCustomer");
                Text = _translator.Translate("customer.addCustomer");
                pageTitle.Text = _translator.Translate("customer.addCustomer");
            }

            nameLabel.Text = _translator.Translate("customer.name");
            address1Label.Text = _translator.Translate("customer.address1");
            address2Label.Text = _translator.Translate("customer.address2");
            postalCodeLabel.Text = _translator.Translate("customer.postalCode");
            phoneLabel.Text = _translator.Translate("customer.phone");
            cityLabel.Text = _translator.Translate("customer.city");
            countryLabel.Text = _translator.Translate("customer.country");
            activeCheckbox.Text = _translator.Translate("customer.active");
            submitBtn.Text = _translator.Translate("submit");
            cancelBtn.Text = _translator.Translate("cancel");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            if (_customer == null)
            {
                var newCustomer = new Customer
                {
                    Name = nameInput.Text,
                    Active = activeCheckbox.Checked ? 1 : 0,
                    Address = new Address
                    {
                        Address1 = address1Input.Text,
                        Address2 = address2Input.Text,
                        PostalCode = postalCodeInput.Text,
                        Phone = phoneInput.Text,
                        City = new City
                        {
                            Name = cityInput.Text,
                            Country = new Country
                            {
                                Name = countryInput.Text,
                                CreatedBy = _currentUser.Name,
                                LastUpdateBy = _currentUser.Name,
                            },
                            CreatedBy = _currentUser.Name,
                            LastUpdateBy = _currentUser.Name,
                        },
                        CreatedBy = _currentUser.Name,
                        LastUpdateBy = _currentUser.Name,
                    },
                    CreatedBy = _currentUser.Name,
                    LastUpdateBy = _currentUser.Name,
                };
                await SubmitAsync(newCustomer, _customerRepository.CreateAsync);
            }
            else
            {
                var customer = new Customer
                {
                    Id = _customer.Id,
                    Name = nameInput.Text,
                    Active = activeCheckbox.Checked ? 1 : 0,
                    LastUpdateBy = _currentUser.Name,
                    AddressId = _customer.AddressId,
                    Address = new Address
                    {
                        Id = _customer.AddressId,
                        CityId = _customer.Address.CityId,
                        Address1 = address1Input.Text,
                        Address2 = address2Input.Text,
                        PostalCode = postalCodeInput.Text,
                        Phone = phoneInput.Text,
                        LastUpdateBy = _currentUser.Name,
                        City = new City
                        {
                            Id = _customer.Address.CityId,
                            CountryId = _customer.Address.City.CountryId,
                            Name = cityInput.Text,
                            LastUpdateBy = _currentUser.Name,
                            Country = new Country
                            {
                                Id = _customer.Address.City.CountryId,
                                Name = countryInput.Text,
                                LastUpdateBy = _currentUser.Name
                            }
                        }
                    }
                };
                await SubmitAsync(customer, _customerRepository.UpdateAsync);
            }
        }

        private async Task SubmitAsync(Customer customer, Func<Customer, Task<int>> callback)
        {
            try
            {
                var result = await callback(customer);

                if (result == 0)
                {
                    MessageBox.Show(_translator.Translate("unexpectedError"));
                    return;
                }

                Close();
            }
            catch (InvalidCustomerException ex)
            {
                errorText.Visible = true;
                errorText.Text = _translator.Translate($"customer.{ex.PropertyName}Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(_translator.Translate("unexpectedError"));
            }
        }
    }
}
