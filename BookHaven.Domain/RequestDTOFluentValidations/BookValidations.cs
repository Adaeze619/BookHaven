//using BookHaven.Domain.RequestDTO;
//using FluentValidation;

//namespace BookHaven.Domain.RequestDTOFluentValidations
//{
//    public class BookValidations : AbstractValidator<AddBookPostRequest>
//    {
//        public BookValidations()
//        {
            

//            RuleFor(post => post.BookTitle)
//                .NotEmpty()
//                .WithMessage("Page Title is required.")
//                .MaximumLength(255)
//                .WithMessage("Page Title cannot exceed 255 characters.");

            
//            RuleFor(post => post.Description)
//                .MaximumLength(500)
//                .WithMessage("Short Description cannot exceed 500 characters.");

//            RuleFor(post => post.ImageUrlHandle)
//                .MaximumLength(255)
//                .WithMessage(" Image URL cannot exceed 255 characters.")
//                .Must(BeAValidUrl).WithMessage("Featured image URL is not valid.");

           

//            RuleFor(post => post.PublishedDate)
//                .NotNull()
//                .WithMessage("Published Date is required.")
//                .LessThanOrEqualTo(DateTime.Now)
//                .WithMessage("Published Date cannot be in the future.");

//            RuleFor(post => post.Author)
//                .NotEmpty()
//                .WithMessage("Author is required.")
//                .MaximumLength(100)
//                .WithMessage("Author name cannot exceed 100 characters.");
//        }

//        private bool BeAValidUrl(string url)
//        {
//        //    //checks whether the created Uri has a scheme of "http" or "https." 
//           Uri result;
//          return Uri.TryCreate(url, UriKind.Absolute, out result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
//        }
//    }
    
//    }

