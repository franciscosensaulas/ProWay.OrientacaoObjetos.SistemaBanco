using FluentValidation;
using Globalization.Resources;
using Service.Extensions;
using Service.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    public class UsuarioViewModelValidation : AbstractValidator<UsuarioViewModel>
    {
        public UsuarioViewModelValidation()
        {
            ValidarLogin();
            ValidarSenha();
        }

        private void ValidarSenha()
        {
            RuleFor(x => x.Senha)
                .NotNull()
                    .WithMessage(Resource.FieldNotNull.Format(nameof(UsuarioViewModel.Senha)))
                .MinimumLength(3)
                    .WithMessage(Resource.FieldMinLength.Format(nameof(UsuarioViewModel.Senha), 3))
                .MaximumLength(30)
                    .WithMessage(Resource.FieldMaxLength.Format(nameof(UsuarioViewModel.Senha), 30));
        }

        private void ValidarLogin()
        {
            RuleFor(x => x.Login)
                .NotNull()
                    .WithMessage(Resource.FieldNotNull.Format(nameof(UsuarioViewModel.Login)))
                .MinimumLength(8)
                    .WithMessage(Resource.FieldMinLength.Format(nameof(UsuarioViewModel.Login), 8))
                .MaximumLength(70)
                    .WithMessage(Resource.FieldMaxLength.Format(nameof(UsuarioViewModel.Login), 70));
               
        }
    }
}
