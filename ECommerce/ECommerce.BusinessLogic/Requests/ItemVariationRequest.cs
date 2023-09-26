using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLogic.Requests
{
    public class ItemVariationRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceVariation { get; set; }
    }
}
