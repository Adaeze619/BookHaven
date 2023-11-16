using BookHaven.Domain.RequestDTO;
using FluentValidation;

namespace BookHaven.Domain.RequestDTOFluentValidations
{
    public class BookHavenTagValidation : AbstractValidator<BookHavenTagRequestDTO>
    {
        public BookHavenTagValidation()
        {
            RuleFor(tag => tag.Name)
         .NotEmpty()
         .WithMessage("Tag Name is required.")
         .MaximumLength(255)
         .WithMessage("Tag Name cannot exceed 255 characters.");
        }
    
        
    }
}
