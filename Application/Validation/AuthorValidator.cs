﻿using Application.DTO;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validation
{
    public class AuthorValidator : AbstractValidator<AuthorCreateDTO>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Firstname is required")
                .MaximumLength(20).WithMessage("The firstname is too long")
                .MinimumLength(2).WithMessage("The firstname is too short")
                .Must(BeAValidText).WithMessage("Incorrect firstname");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Lastname is required")
                .MaximumLength(20).WithMessage("The lastname is too long")
                .MinimumLength(2).WithMessage("The lastname is too short")
                .Must(BeAValidText).WithMessage("Incorrect lastname");
        }

        private bool BeAValidText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            var regex = new Regex(@"^[A-Za-z\s]+$");

            return regex.IsMatch(text);
        }
    }
}
