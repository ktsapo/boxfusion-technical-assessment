using Employees.Domain.Common.Utils;

namespace Employees.Domain.Skills.ValueObjects
{
    /// <summary>
    /// Value object to represent the unique identifier of a skill.
    /// </summary>
    public class SkillId
    {
        

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; }

        public SkillId(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        private SkillId()
        {
        }

        /// <summary>
        /// Create a new Skill Id value object, assigning it the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SkillId Create(string value)
        {
            return new(value);
        }

        /// <summary>
        /// Create a new Skill Id value object with a unique value (Guid).
        /// </summary>
        /// <returns></returns>
        public static SkillId CreateUnique()
        {
            return new(IdGenerationUtils.GenerateGuidAsString());
        }
    }
}
