using System;
using System.Collections.Generic;
using System.Text;
using Uibasoft.Smedia.Core.QueryFilters;
using Uibasoft.Smedia.DataAccess.Interfaces;

namespace Uibasoft.Smedia.DataAccess.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostPaginationUrl(PostQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
