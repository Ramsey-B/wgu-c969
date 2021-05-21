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
        private readonly ITranslator _translator;

        public ModifyCustomer(User currentUser, ITranslator translator, ICustomerRepository customerRepository, int? customerId = null)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _translator = translator;
            _customerRepository = customerRepository;
            Init(customerId);
        }

        private void Init(int? customerId = null)
        {
            if (customerId != null) // if we have a customer Id  then we're editing the customer
            {
                _customer = _customerRepository.GetAsync((int)customerId).Result; // get the customers full details

                nameInput.Text = _customer.Name;
                address1Input.Text = _customer.Address1;
                address2Input.Text = _customer.Address2;
                postalCodeInput.Text = _customer.PostalCode;
                phoneInput.Text = _customer.Phone;
                cityInput.Text = _customer.City;
                countryInput.Text = _customer.Country;
                activeCheckbox.Checked = _customer.Active;
            }
            TranslatePage();
        }

        private void TranslatePage()
        {
            if (_customer != null) // edit customer
            {
                Name = _translator.Translate("customer.editCustomer");
                Text = _translator.Translate("customer.editCustomer");
                pageTitle.Text = _translator.Translate("customer.editCustomer");
            } 
            else // create customer
            {
                Name = _translator.Translate("customer.addCustomer");
                Text = _translator.Translate("customer.addCustomer");
                pageTitle.Text = _translator.Translate("customer.addCustomer");
            }

            nameLabel.Text = _translator.Translate("name");
            address1Label.Text = _translator.Translate("customer.address1");
            address2Label.Text = _translator.Translate("customer.address2");
            postalCodeLabel.Text = _translator.Translate("customer.postalCode");
            phoneLabel.Text = _translator.Translate("customer.phone");
            cityLabel.Text = _translator.Translate("customer.city");
            countryLabel.Text = _translator.Translate("customer.country");
            activeCheckbox.Text = _translator.Translate("active");
            submitBtn.Text = _translator.Translate("submit");
            cancelBtn.Text = _translator.Translate("cancel");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            if (_customer == null) // create new customer
            {
                var newCustomer = new Customer
                {
                    Name = nameInput.Text,
                    Active = activeCheckbox.Checked,
                    Address1 = address1Input.Text,
                    Address2 = address2Input.Text,
                    PostalCode = postalCodeInput.Text,
                    Phone = phoneInput.Text,
                    City = cityInput.Text,
                    Country = countryInput.Text,
                    CreatedBy = _currentUser.Username,
                    LastUpdatedBy = _currentUser.Username,
                };
                await SubmitAsync(newCustomer, _customerRepository.CreateAsync); // pass the create func 
            }
            else // edit existing customer
            {
                var customer = new Customer
                {
                    Id = _customer.Id,
                    Name = nameInput.Text,
                    Active = activeCheckbox.Checked,
                    LastUpdatedBy = _currentUser.Username,
                    AddressId = _customer.AddressId,
                    CityId = _customer.CityId,
                    Address1 = address1Input.Text,
                    Address2 = address2Input.Text,
                    PostalCode = postalCodeInput.Text,
                    Phone = phoneInput.Text,
                    City = cityInput.Text,
                    Country = countryInput.Text,
                    CountryId = _customer.CountryId
                };
                await SubmitAsync(customer, _customerRepository.UpdateAsync); // pass the update create func
            }
        }

        private async Task SubmitAsync(Customer customer, Func<Customer, Task<int>> callback)
        {
            try
            {
                var result = await callback(customer); // invoke the callback with the customer

                if (result == 0) // failed to create/update the customer
                {
                    MessageBox.Show(_translator.Translate("unexpectedError"));
                    return;
                }

                Close();
            }
            catch (InvalidEntityException ex) // handle if the customer is invalid
            {
                errorText.Visible = true;
                errorText.Text = _translator.Translate($"customer.{ex.PropertyName}Error");
            }
            catch (Exception)
            {
                MessageBox.Show(_translator.Translate("unexpectedError"));
            }
        }
    }
}
