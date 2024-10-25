using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator: AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz!");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazar başlığını boş geçemezsiniz!");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar görselini boş geçemezsiniz!");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar hakkında kısmını boş geçemezsiniz!");
        }
    }
}
