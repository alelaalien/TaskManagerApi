using TaskManager.Domain.QueryFilters;
using TaskManager.Infraestructure.Interfaces;

namespace TaskManager.Infraestructure.Services

{
    public class UriService : IUriService
    {
        private readonly string _baseUrl;
        public UriService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Uri GestActivitiesPaginationUri(ActivityQueryFilter filters, string actionUrl)
        {
            var url = $"{_baseUrl}{actionUrl}";
            return new Uri(url);
        }
    }
}
