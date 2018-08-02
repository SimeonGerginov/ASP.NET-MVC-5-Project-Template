using System;

namespace MVC5_Template.Core.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
