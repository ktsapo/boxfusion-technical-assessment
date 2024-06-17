using Employees.Domain.Common.Models;
using Employees.Domain.Employees.ValueObjects;
using Employees.Domain.Skills.Enums;
using Employees.Domain.Skills.ValueObjects;

namespace Employees.Domain.Skills
{
    /// <summary>
    /// Skills to be saved in the database.
    /// </summary>
    public class EmployeeSkill: Entity<SkillId>
    {
        public string Name { get; private set; }

        public int YearsOfExperience { get; private set; }

        public SeniorityRating SeniorityRating { get; private set; }

        private EmployeeSkill(SkillId skillId, string name, int yearsOfExperience, SeniorityRating seniorityRating) : base(skillId)
        {
            Name = name;
            YearsOfExperience = yearsOfExperience;
            SeniorityRating = seniorityRating;
        }

        private EmployeeSkill()
        {
        }

        /// <summary>
        /// Create an employee skill entity from the given parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="yearsOfExperience"></param>
        /// <param name="seniorityRating"></param>
        /// <returns></returns>
        public static EmployeeSkill Create(string name, int yearsOfExperience, SeniorityRating seniorityRating)
        {
            return new(SkillId.CreateUnique(), name, yearsOfExperience, seniorityRating);
        }
    }
}
