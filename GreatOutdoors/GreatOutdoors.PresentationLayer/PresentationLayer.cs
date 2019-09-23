using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GO.Entities;
using GO.DAL;
using GO.BL;


namespace GreatOutdoors.PresentationLayer
{
    class PresentationLayer
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Great Outdoors..");

            

            SalesUser s1 = new SalesUser();
            s1.Name = "ABC";
            s1.UserName = "abc123";
            s1.Email = "lihfl@dk.com";
            s1.SalesManID = 12341;

            if(SalesBL.AddSalesUserBL(s1))
            {
                Console.WriteLine(s1.Name);
                Console.WriteLine(s1.UserName);
                Console.WriteLine(s1.Email);
                Console.WriteLine(s1.SalesManID);
            }

            else
                Console.WriteLine("Error in adding salesman");



           

        }
    }
}
