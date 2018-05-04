using System.Web.Mvc;
using Bytes2you.Validation;
using MVC5_Template.Core.Contracts;

namespace MVC5_Template.Infrastructure.Filters
{
    public class SaveChangesFilter : IActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public SaveChangesFilter(IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(unitOfWork, "Unit of work").IsNull().Throw();

            this.unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.unitOfWork.Complete();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Just to satisfy the interface. Cannot decouple from it.
        }
    }
}
