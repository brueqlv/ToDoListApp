using FluentValidation;

namespace ToDoListApp.Models.Validators
{
    public class ToDoItemValidator : AbstractValidator<ToDoItem>
    {
        public ToDoItemValidator()
        {
            RuleFor(i => i.Title)
                .NotEmpty()
                .Length(3, 40);
            RuleFor(i => i.Description)
                .MaximumLength(200);
        }
    }
}
