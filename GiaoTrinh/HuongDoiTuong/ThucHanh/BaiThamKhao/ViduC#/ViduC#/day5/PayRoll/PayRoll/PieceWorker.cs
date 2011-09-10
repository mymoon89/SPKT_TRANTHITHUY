using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayRoll
{
    public class PieceWorker : Employee 
   {
      private decimal wagePerPiece; // wage per piece produced
      private int quantity;         // quantity of pieces produced
   
      // constructor
      public PieceWorker( string firstNameValue, string lastNameValue, 
	decimal wagePerPieceValue, int quantityValue )
         : base( firstNameValue, lastNameValue )
      {
         WagePerPiece = wagePerPieceValue;
         Quantity = quantityValue;
      }
   
      // property WagePerPiece
      public decimal WagePerPiece
      {
         get
         {
            return wagePerPiece;
         }
   
         set
         {
            if ( value > 0 )
               wagePerPiece = value;
         }
      }
      public int Quantity
      {
          get
          {
              return quantity;
          }

          set
          {
              if (value > 0)
                  quantity = value;
          }
      }

      // override base-class method to calculate 
      // PieceWorker's earnings
      public override decimal Earnings()
      {
          return Quantity * WagePerPiece;
      }

      // return string representation of PieceWorker
      public override string ToString()
      {
          return "PieceWorker: " + base.ToString();
      }
   }
}
