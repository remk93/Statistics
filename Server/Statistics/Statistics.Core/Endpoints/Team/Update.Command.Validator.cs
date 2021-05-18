using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Statistics.DataStorage.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Core.Endoints.Team
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        private readonly IDbContextFactory<EntitiesContext> _contextFactory;

        public UpdateCommandValidator(IDbContextFactory<EntitiesContext> contextFactory)
        {
            _contextFactory = contextFactory;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Team name should be fill-in");

            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Team short name should be fill-in")
                .Must(x => x.Length > 1 && x.Length <= 3)
                .WithMessage("Team short name should have 2 or 3 symbols")
                .Must(CheckExistCode);

            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("Team city should be fill-in");

            RuleFor(x => x.Conference)
                .NotNull()
                .NotEmpty()
                .WithMessage("Team conference should be fill-in");

            RuleFor(x => x.Division)
                .NotNull()
                .NotEmpty()
                .WithMessage("Team division should be fill-in");

            RuleFor(x => x.Logo)
                .NotNull()
                .NotEmpty()
                .WithMessage("Team Logo should be fill-in");
        }

        private bool CheckExistCode(string code)
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Teams.FirstOrDefaultAsync(x => x.Code == code) != null;
        }
    }
}
