using System;
using System.Collections.Generic;

namespace Retail.Stores
{
    public interface RetailShops
    {
     // Would like to make varibles for Relavant identifiers we might run into when querying the transaction data
     // ie. For Walmart : "WALMART", "Walmart", "WALMARTCOM", etc. 
        public List<string> IDs {get;set;}
         
    }
}