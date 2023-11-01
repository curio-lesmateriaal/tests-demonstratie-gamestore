using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class Receipt
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<GameReceipt> GameReceipts { get; set; } = new List<GameReceipt>(); // navigation property (one-to-many)
        public ICollection<Game> Games { get; set; } // 'skip' navigation property (many-to-many) - gaat alsnog via koppeltabel GameReceipts

        public decimal TotalPrice => GameReceipts.Select(gr => gr.TotalPrice).Sum();

        /// <summary>
        /// Adds a game to the receipt, adding to the amount if it exists on the reciept
        /// </summary>
        /// <param name="game"></param>
        public void AddGame(Game game)
        {
            var existingRow = GameReceipts.FirstOrDefault(gr => gr.Game.Id == game.Id);

            if (existingRow != null)
            {
                existingRow.Amount++;
                return;
            }

            // Add new row to receipt
            GameReceipts.Add(new GameReceipt
            {
                Amount = 1,
                Game = game,
                Receipt = this,
                UnitPrice = game.Price
            });
        }

        public void RemoveGame(Game game)
        {
            var existingRow = GameReceipts.FirstOrDefault(gr => gr.Game.Id == game.Id);

            if (existingRow != null)
            {
                existingRow.Amount--;
            }

            if(existingRow.Amount > 0)
            {
                return;
            }

            GameReceipts.Remove(existingRow);
        }
    }
}
