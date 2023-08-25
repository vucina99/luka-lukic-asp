using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        public string Recipient { get; set; }
        public string Adress { get; set; }
        public decimal SumPrice { get; set; }
        public User User { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}
