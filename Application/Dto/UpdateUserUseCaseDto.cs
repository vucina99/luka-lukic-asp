using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdateUserUseCaseDto
    {
        public IEnumerable<int> UseCaseIds { get; set; }
        public int UserId { get; set; }
    }
}
