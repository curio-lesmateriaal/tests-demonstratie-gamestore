using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class GameReceipt
    {
        public int GameId { get; set; }
        public int ReceiptId { get; set; }

        public int Amount { get; set; }

        /// <summary>
        /// Since prices may change over time, we'll log the exact price at the time in the receipt rule
        /// </summary>
        public decimal UnitPrice { get; set; }
        
        public decimal TotalPrice
        {
            get => Amount * UnitPrice;
        }
        public string TotalPriceFormatted => FormatHelper.FormatMoney(TotalPrice);

        public Game Game { get; set; } // navigation property
        public Receipt Receipt { get; set; } // navigation property
    }
}
