using TaskManager.Domain.QueryFilters;

namespace TaskManager.Infraestructure.Interfaces
{
    public interface IUriService
    {
        Uri GestActivitiesPaginationUri(ActivityQueryFilter filters, string actionUrl);
    }
}