using A5bark.Core.BuildingBlocks;

namespace A5bark.Core.Exceptions
{
    public class BusinessRuleValidationException : DomainException
    {
        public IBusinessRule BusinessRule { get; }

        public BusinessRuleValidationException(IBusinessRule businessRule)
            : base(businessRule.Message)
                => BusinessRule = businessRule;
    }
}
