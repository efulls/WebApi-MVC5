using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsumeXml.Models
{
    public class Customer
    {
        ///<summary>
        /// Gets or sets CustomerId.
        ///</summary>
        public int CustomerId { get; set; }

        ///<summary>
        /// Gets or sets Name.
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// Gets or sets Country.
        ///</summary>
        public string Country { get; set; }
    }
}