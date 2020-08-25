using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Demonstration.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }

        //Note that we have included a 'Customer' object as a navigation property; there will be one customer per order.
        //The CustomerId serves as a Foreign Key for the data tables.  If we don't specify it, Entity will automatically 
        //generate it as a  "shadow property"
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

    }
}
