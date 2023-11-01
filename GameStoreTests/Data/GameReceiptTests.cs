using GameStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreTests.Data
{
    [TestClass]
    public class GameReceiptTests
    {
        [TestMethod]
        public void GameReceipt_CalculatesTotalPriceCorrectly()
        {
            // Arrange
            var gameReceipt = new GameReceipt
            {
                Amount = 2,
                UnitPrice = 50.0m
            };

            // Act
            var totalPrice = gameReceipt.TotalPrice;

            // Assert
            Assert.AreEqual(100m, totalPrice, "Total price should be the product of amount and unit price.");
        }

        [TestMethod]
        public void Receipt_AddGame_IncreasesTotalPrice()
        {
            // Arrange
            var game = new Game { Id = 1, Price = 60.0m };
            var receipt = new Receipt();

            // Act
            receipt.AddGame(game);
            receipt.AddGame(game); // Adding same game twice

            // Assert
            var gameReceipt = receipt.GameReceipts.First(gr => gr.Game.Id == game.Id);
            Assert.AreEqual(2, gameReceipt.Amount, "Game should be added twice.");
            Assert.AreEqual(120m, receipt.TotalPrice, "Total price should reflect the sum of all games added.");
        }

        [TestMethod]
        public void Receipt_RemoveGame_DecreasesAmountOrRemovesGame()
        {
            // Arrange
            var game = new Game { Id = 1, Price = 30.0m };
            var receipt = new Receipt();
            receipt.AddGame(game);
            receipt.AddGame(game); // Game amount should now be 2

            // Act
            receipt.RemoveGame(game);

            // Assert
            Assert.AreEqual(1, receipt.GameReceipts.First(gr => gr.Game.Id == game.Id).Amount, "Game amount should decrease.");
            receipt.RemoveGame(game); // Removing again should delete the game from the receipt
            Assert.IsFalse(receipt.GameReceipts.Any(gr => gr.Game.Id == game.Id), "Game should be removed from receipt when amount reaches zero.");
        }
    }
}
