using FluentValidation;
using SiesaContact;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(contact => contact._name).NotEmpty();
        RuleFor(contact => contact._landline).NotEmpty();
        RuleFor(contact => contact._cellphone).NotEmpty();
    }
}