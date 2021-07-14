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
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz.");
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu En az 3 Harf Olmalıdır.");
            RuleFor(x => x.ContactName).MinimumLength(3).WithMessage("Kullanıcı Adınız En az 3 Harf Olmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız.");

        }
    }
}
