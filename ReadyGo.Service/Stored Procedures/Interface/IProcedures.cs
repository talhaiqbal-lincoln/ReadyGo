using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Service.Stored_Procedures.Interface
{
    public interface IProcedures
    {
        public void UpdateCustomerBalance(Guid id);
    }
}
