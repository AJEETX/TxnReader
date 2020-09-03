using System;
namespace codeChallenge
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string RelatedTransaction { get; set; }
    }
}