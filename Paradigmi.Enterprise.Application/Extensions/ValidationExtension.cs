﻿using System.Text.RegularExpressions;
using FluentValidation;

namespace Paradigmi.Enterprise.Application.Extensions
{
	public static class ValidationExtension
	{
		public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regex, string validationMessage)
		{
			ruleBuilder.Custom((value, context) =>
			{
				var regEx = new Regex(regex);
				if (regEx.IsMatch(value.ToString()) == false)
				{
					context.AddFailure(validationMessage);
				}
			});
		}
	}
}
