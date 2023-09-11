using Backend.Core.BuildingBlocks;

namespace Backend.Core.Exceptions
{
    public class BusinessRuleValidationException : DomainException
    {
        public IBusinessRule BusinessRule { get; }

        public BusinessRuleValidationException(IBusinessRule businessRule)
            : base(businessRule.Message)
                => BusinessRule = businessRule;
    }
}
