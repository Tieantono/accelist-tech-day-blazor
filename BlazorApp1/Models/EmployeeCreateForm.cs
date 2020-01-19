using BlazorApp1.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class EmployeeCreateForm
    {
        public string Name { set; get; }

        public string Email { set; get; }
    }

    public class EmployeeCreateFormValidator : AbstractValidator<EmployeeCreateForm>
    {
        private readonly DemoDbContext DB;

        public EmployeeCreateFormValidator(DemoDbContext demoDbContext)
        {
            this.DB = demoDbContext;

            RuleFor(Q => Q.Name).NotEmpty().MaximumLength(255);
            RuleFor(Q => Q.Email)
                .NotEmpty()
                .MaximumLength(255)
                .EmailAddress()
                .MustAsync(EmailIsAvailable);
        }

        public async Task<bool> EmailIsAvailable(string email, CancellationToken cancellationToken)
        {
            var exist = await DB.Employees.AsNoTracking()
                .Where(Q => Q.Email == email)
                .AnyAsync();

            return (exist == false);
        }
    }
}
