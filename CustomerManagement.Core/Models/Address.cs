namespace CustomerManagement.Core.Models
{
    public class Address : EntityBase
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
