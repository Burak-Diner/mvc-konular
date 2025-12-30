using FluentValidation;

namespace WebHafta09.Web.Models.Validators
{
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {
        public KullaniciValidator() :base()
        {
            RuleFor(a=>a.KullaniciId).NotNull().NotEmpty();
            RuleFor(a => a.KullaniciAdi)
                .NotNull().WithMessage("Bu alan boş bırakılamaz!")
                .NotEmpty().WithMessage("Bu alan boş bırakılamaz!")
                .MinimumLength(5).WithMessage("Minimum 5 karakter olmalı!")
                .MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı!")
                ;
            RuleFor(a => a.KullaniciSoyadi)
                .NotNull().WithMessage("Bu alan boş bırakılamaz!")
                .NotEmpty().WithMessage("Bu alan boş bırakılamaz!")
                .MinimumLength(5).WithMessage("Minimum 5 karakter olmalı!")
                .MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı!")
                ;
            RuleFor(a => a.KullaniciEmail)
                .NotNull().WithMessage("Bu alan boş bırakılamaz!")
                .NotEmpty().WithMessage("Bu alan boş bırakılamaz!")
                .EmailAddress().WithMessage("Geçerli bir email giriniz.")
                .MinimumLength(5).WithMessage("Minimum 5 karakter olmalı!")
                .MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı!")
                ;


        }
    }
}
