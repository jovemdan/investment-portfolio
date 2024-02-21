using System;
using InvestmentPortfolio.Application.Queries.Investment.GetInvestmentByCustomerId;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Transaction.GetTransactionsByProduct
{
	public class GetTransactionsByProductQueryHandler : IRequestHandler<GetTransactionsByProductQuery, IEnumerable<TransactionViewModel>>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionsByProductQueryHandler(
            ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TransactionViewModel>> Handle(GetTransactionsByProductQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.FindAllByAsync(x => x.ProductId == request.ProductId);
            if (transactions == null) return null;

            var transactionsViewModel = TransactionViewModel.MapFromDomain(transactions);

            return transactionsViewModel;
        }
    }
}

