namespace Employees.Domain.Employees.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class Address
    {
        public string City { get; private set; }

        public string PostalCode { get; private set; }

        public string Country { get; private set; }

        private Address()
        {
        }

        /// <summary>
        /// Initialise an Address
        /// </summary>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <param name="country"></param>
        public Address(string city, string postalCode, string country)
        {
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        /// <summary>
        /// Factory method to create an address item
        /// </summary>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public static Address Create(string city, string postalCode, string country)
        {
            return new(city, postalCode, country);
        }
    }
}
