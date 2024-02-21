﻿using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(Guid productId, TypeEnum type, int quantity, decimal value, DateTime transactionDate)
        {
            ProductId = productId;
            Type = type;
            Quantity = quantity;
            Value = value;
            TransactionDate = transactionDate;
        }

        public Guid ProductId { get; private set; }
        public TypeEnum Type { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}