﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Maili boş geçemezsiniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad kısmını boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konuyu boş geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj içeriğini boş geçemezsiniz");
        }
    }
}
