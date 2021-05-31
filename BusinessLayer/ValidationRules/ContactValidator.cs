using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserEmail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(c => c.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz");
            RuleFor(c => c.UserName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(c => c.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(c => c.Subject).MaximumLength(50).WithMessage("Lütfen en az 3 karakter girişi yapın");
        }
    }
}
