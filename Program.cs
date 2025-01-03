// Program.cs

using System;
using BlockChain.Entity;
namespace BlockChain;

class Program
{
    static void Main()
    {
        var blockchain = new Blockchain();

        // Adding blocks to the blockchain
        blockchain.AddBlock("Transaction 01");
        blockchain.AddBlock("Transaction 02");

        // Displaying the blockchain
        DisplayBlockchain(blockchain);
    }

    static void DisplayBlockchain(Blockchain blockchain)
    {
        foreach (var block in blockchain.GetChain())
        {
            Console.WriteLine($"Index: {block.Index}");
            Console.WriteLine($"Timestamp: {block.TimeStamp}");
            Console.WriteLine($"Data: {block.Data}");
            Console.WriteLine($"Previous Hash: {block.PreviousHash}");
            Console.WriteLine($"Hash: {block.Hash}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
