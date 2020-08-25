using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Demonstration.Models
{
    //This class serves as a model for a junction table to link Product-Order data.  Just as in other classes, the foreign
    //object Id values represent ForeignKey relationships and aren't strictly required (but suggested anyway) by Entity.
    public class ProductOrder
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId {get; set; }
        public int OrderId { get; set;}
        

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
