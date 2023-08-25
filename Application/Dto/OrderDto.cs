using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class MakeOrderDto
    {
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Recipient { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }

    public class OrderLineDto
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        public string Recipient { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }
}
