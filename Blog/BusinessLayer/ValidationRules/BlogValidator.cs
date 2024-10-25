using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz!");
            RuleFor(x => x.BlogTitle).MinimumLength(2).WithMessage("Lütfen en az 2 karakterlik blog başlığı girişi yapınız!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("En fazla 150 karakterlik blog başlığı girişi yapabilirsiniz!");
        }
    }
}
