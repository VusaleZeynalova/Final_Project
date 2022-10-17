using Core.CoreEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CoreEntities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }



    }
}
