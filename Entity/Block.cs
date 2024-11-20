// Block.cs

using System;
namespace BlockChain.Entity;

public class Block
{
    public int Index { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Data { get; set; }
    public string PreviousHash { get; set; }
    public string Hash { get; set; }
}
