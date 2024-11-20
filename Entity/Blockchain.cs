using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Entity
{
    public class Blockchain
    {
        private List<Block> _chain;
        public Blockchain()
        {
            _chain = new List<Block>();
            AddGenesisBlock();
        }

        private void AddGenesisBlock()
        {
            _chain.Add(new Block
            {
                Index = 0,
                TimeStamp = DateTime.Now,
                Data = "Genesis Block",
                PreviousHash = "0",
                Hash = CalculateHash(0, DateTime.Now, "Genesis Block", "0")
            });
        }

        public void AddBlock(string data)
        {
            var previousBlock = _chain[_chain.Count - 1];
            var newBlock = new Block
            {
                Index = previousBlock.Index + 1,
                TimeStamp = DateTime.Now,
                Data = data,
                PreviousHash = previousBlock.Hash,
                Hash = CalculateHash(previousBlock.Index + 1, DateTime.Now, data, previousBlock.Hash)
            };
            _chain.Add(newBlock);
        }

        private string CalculateHash(int index, DateTime timestamp, string data, string previoushash)
        {
            using (var sha256 = SHA256.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes($"{index}-{timestamp}-{data}-{previoushash}");
                var hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
        public List<Block> GetChain()
        {
            return _chain;
        }
    }
}