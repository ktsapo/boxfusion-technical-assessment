using Employees.Contracts.Employees;
using Employees.Domain.Employees.Repository;
using MediatR;

namespace Employees.Application.Features.Employees.Queries
{
    public class SearchEmployeeQueryHandler : IRequestHandler<SearchEmployeeQuery, List<EmployeeResponse>>
    {

        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeRepository"></param>
        public SearchEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Search for employees using the given criteria
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<EmployeeResponse>> Handle(SearchEmployeeQuery request, CancellationToken cancellationToken)
        {

            var employees = await _employeeRepository.Search(request.searchQuery);

            return employees.ToList();
        }
    }
}
