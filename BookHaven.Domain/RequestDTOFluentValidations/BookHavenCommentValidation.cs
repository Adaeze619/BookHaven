using BookHaven.Domain.RequestDTO;
using FluentValidation;

namespace BookHaven.Domain.RequestDTOFluentValidations
{
    public class BookHavenCommentValidation : AbstractValidator<BookHavenCommentRequestDTO>
    {
        public BookHavenCommentValidation()
        {
            RuleFor(comment => comment.Description)
                .Matches("^[a-zA-Z]+$")
                .WithMessage("Description should contain alphabets.");
        }
    }
    

    
}
