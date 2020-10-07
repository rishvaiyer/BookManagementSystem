using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using Utilities;

using System.Data;

namespace BookLibrary
{


    public class Updating
    {
        DBConnect objDB = new DBConnect();
        


        public void updateTheDB(string ISBN, string Type, string RentOrBuy, string Quantity, double totalPrice)
        {
            DBConnect objDB = new DBConnect();
           
           
            int quantityInt;
           
            DataSet TSds;
           

         

            String getTS = "SELECT TotalSales FROM Books WHERE ISBN = '" + ISBN + "'";
            TSds = objDB.GetDataSet(getTS);

            
            

        
            int.TryParse(Quantity, out quantityInt);
           
            String UpdateTotalSales = "UPDATE Books SET TotalSales = TotalSales + " +  totalPrice + " WHERE ISBN = '" + ISBN + "'";
            objDB.DoUpdate(UpdateTotalSales);

          

            if (RentOrBuy == "Rent")
            {
                String updateTQR = "UPDATE Books SET TotalQuantityRented = TotalQuantityRented + " + quantityInt  + " WHERE ISBN = '" + ISBN + "'";
                objDB.DoUpdate(updateTQR);
                
            }
            else if (RentOrBuy == "Buy") {
                String updateTQS = "UPDATE Books SET TotalQuantitySold = TotalQuantitySold + " + quantityInt + " WHERE ISBN = '" + ISBN + "'";
                objDB.DoUpdate(updateTQS);




            }
               
                
               
               
           
           


        }

        

    }
    
}
