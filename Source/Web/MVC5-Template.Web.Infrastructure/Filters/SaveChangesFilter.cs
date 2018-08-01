using System.Web.Mvc;
using Bytes2you.Validation;
using MVC5_Template.Core.Contracts;

namespace MVC5_Template.Web.Infrastructure.Filters
{
    public class SaveChangesFilter : IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaveChangesFilter(IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(unitOfWork, "Unit of work").IsNull().Throw();

            this._unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this._unitOfWork.Complete();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Just to satisfy the interface. Cannot decouple from it.
        }
    }
}
