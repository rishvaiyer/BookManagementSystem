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
  public  class Calculate
    {
        DBConnect objDB = new DBConnect();
        Double cost;
        int quantity;
        Double total;
        Double finalTotal;

        public double getPrice(string ISBN, string Type, string RentOrBuy, string Quantity)
        {
            string sqlStrGetPrice;
            sqlStrGetPrice = "SELECT BasePrice FROM Books WHERE ISBN ='" + ISBN + "'";
            DataSet priceData = objDB.GetDataSet(sqlStrGetPrice);
            cost = Convert.ToDouble(objDB.GetField("BasePrice", 0));

            if (Type == "Ebook" && RentOrBuy == "Rent")
            {
                total = (cost + 0);
            }
            else if (Type == "Ebook" && RentOrBuy == "Buy")
            {
                total = (cost + 33.00);
            }
            else if (Type == "Hardcopy" && RentOrBuy == "Rent")
            {
                total = (cost + 30.00);
            }

            else if(Type=="Hardcopy" && RentOrBuy=="Buy")
            {
                total = (cost + 77.00);

            }

            else if(Type=="Paperback" && RentOrBuy=="Rent")
            {
                total = (cost + 23.00);


            }
            else if(Type=="Paperback" && RentOrBuy=="Buy")
            {
                total = (cost + 45.00);
            }

            int.TryParse(Quantity, out quantity);
            finalTotal = quantity * total;
            return finalTotal;

        }
          
    }
}

