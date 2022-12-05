using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model  
{
    public class DqwIncompleteModel
    {
        public List<Product_type> UverseQueue { get; set; }     
        public List<Product_type> AwbQueue { get; set; }   
        public List<Product_type> PotsQueue { get; set; }   
    }
}
