using System;
using FluentValidation.Results;
using MediatR;

namespace InvestmentPortfolio.Application.Commands.RemoveInvestment
{
	public class RemoveInvestmentCommand : Command, IRequest<ValidationResult>
    {
        public RemoveInvestmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}

