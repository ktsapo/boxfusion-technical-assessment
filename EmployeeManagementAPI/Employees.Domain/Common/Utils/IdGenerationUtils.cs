using System.Text;

namespace Employees.Domain.Common.Utils
{
    /// <summary>
    /// Generation of unique identifiers for database primary keys.
    /// </summary>
    public static class IdGenerationUtils
    {
        /// <summary>
        /// Generates employee Id using the following rules:
        /// 1. The id should be a string with 2 random uppercase letters followed by 4 random numbers.
        /// </summary>
        /// <returns></returns>
        public static string GenerateEmployeeId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();

            var idStringBuilder = new StringBuilder();

            var randomUpperCaseLetters = new string(
                Enumerable.Repeat(chars, 2)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

            idStringBuilder.Append(randomUpperCaseLetters);

            var randomNumbers = random.Next(1000, 9999).ToString();

            idStringBuilder.Append(randomNumbers);

            return idStringBuilder.ToString();
        }


        /// <summary>
        /// Generates a unique identifier using a GUID.
        /// </summary>
        /// <returns></returns>
        public static string GenerateGuidAsString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
