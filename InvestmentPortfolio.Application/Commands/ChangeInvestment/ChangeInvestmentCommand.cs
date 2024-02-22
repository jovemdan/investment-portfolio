using System;
using System.Text.Json.Serialization;
using FluentValidation.Results;
using MediatR;

namespace InvestmentPortfolio.Application.Commands.ChangeInvestment
{
	public class ChangeInvestmentCommand : Command, IRequest<ValidationResult>
    {
		public ChangeInvestmentCommand(Guid id, bool isAvailable)
		{
            Id = id;
            IsAvailable = isAvailable;
		}

        public Guid Id { get; set; }

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}

