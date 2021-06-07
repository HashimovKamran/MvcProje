using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");
            RuleFor(m => m.ReceiverMail).EmailAddress().WithMessage("Düzgün email adresi geçin");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(m => m.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(m => m.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayın");
        }
    }
}
