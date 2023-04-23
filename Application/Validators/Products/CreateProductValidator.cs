using Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("İsim alanı zorunludur.")
                .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Ürün adı 50 karakteri geçmemelidir.")
                .MinimumLength(3).WithMessage("Ürün adı 3 karakterden uzun olmalıdır");
            RuleFor(p => p.Price)
                .NotNull().WithMessage("Fiyat Alanı Zorunludur")
                .GreaterThan(0).WithMessage("Fiyat 0'dan küçük olamaz.");
            RuleFor(p =>p.Stock)
                .NotNull().WithMessage("Stok alanı zorunludur.")
                .GreaterThan(0).WithMessage("Stok 0'dan küçük olamaz.");
        }
    }
}
