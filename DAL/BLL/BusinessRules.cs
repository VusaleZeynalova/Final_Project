using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BLL
{
  public static  class BusinessRules
    {
        public static  IResult Run(params IResult[] logics)
        {
            foreach (var l in logics)
            {
                if (!l.Success)
                {
                    return l;
                }
            }
            return null;
        }
    }
}
