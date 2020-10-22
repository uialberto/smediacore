using System;
using Uibasoft.Smedia.Core.QueryFilters;

namespace Uibasoft.Smedia.DataAccess.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUrl(PostQueryFilter filter, string actionUrl);
    }
}