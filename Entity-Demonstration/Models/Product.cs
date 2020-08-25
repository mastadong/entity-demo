using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity_Demonstration.Models
{
    public class Product
    {
        //In Entity, 'Id' is a keyword that indicates the property should be treated as the primary key in the table that will be built.  
        //However, if we wish to be as explicit as possible, we should set the Attribute tag for 'key'
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(17,2)")]
        public decimal Price { get; set; }
    }
}
