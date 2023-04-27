using System;
using FluentValidation.Results;

namespace MideiatrPipelinesApi
{
	public class ValidationFailed
	{

		public ValidationFailed(List<ValidationFailure> failures)
		{
			Failures = failures;
		}
		public List<ValidationFailure> Failures { get; init; }
	}
}

