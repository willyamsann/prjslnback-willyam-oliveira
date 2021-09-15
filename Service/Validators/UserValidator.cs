using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor insira o nome.")
                .NotNull().WithMessage("Por favor insira o nome.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor insira o email.")
                .NotNull().WithMessage("Por favor insira o email.")
              .EmailAddress()
                         .WithMessage("Invalido Email Formato.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Por favor insira a senha.")
                .NotNull().WithMessage("Por favor insira a senha.")
                .MinimumLength(10).WithMessage("O tamanho minimo é de 10 caracteres")
                    .Must(ValidateRepeatedCharacters).WithMessage("Existem caracteres em sequencia repetidos")
                    .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter pelo menos uma letra maiúscula.")
                    .Matches(@"[a-z]+").WithMessage("Sua senha deve conter pelo menos uma letra miniscula.")
                    .Matches(@"[0-9]+").WithMessage("Sua senha deve conter pelo menos um numero.")
                    .Matches(@"[\!\?\*\.\@\#\-\!]+").WithMessage("Sua senha deve conter pelo menos um (!? *.).");
        }

        private bool ValidateRepeatedCharacters(string password)
        {
            if (password.Length == 0)
            {
                return true;
            }
            char current = password[0];
            for(int i =0; i < password.Length; i++)
            {
                char next = password[i];
                if(i != 0)
                {
                    if (next == current)
                    {
                        return false;
                    }
                    current = next;
                }
                
            }

         
            return true;
        }

    }
}
