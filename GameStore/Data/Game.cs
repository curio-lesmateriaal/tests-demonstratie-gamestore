using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<GameReceipt> GameReceipts { get; set; } // navigation property (one-to-many)
        public ICollection<Receipt> Receipts { get; set; } // 'skip' navigation property (many-to-many) - gaat alsnog via koppeltabel GameReceipts

        public string PriceFormatted => FormatHelper.FormatMoney(Price);
    }
}
