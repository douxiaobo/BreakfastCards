using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast_Cards_Manage_System.Models
{
    public class Cards
    {
        public int Year_Month { get; set; }
        public List<Card> cards { get; }=new List<Card>();
    }
}
