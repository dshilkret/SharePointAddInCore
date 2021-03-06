﻿using SharePointAddInCore.Core.SharePointClient.Models;

using System;
using System.Threading.Tasks;

namespace SharePointAddInCore.Core.SharePointClient
{
    internal interface ISharePointClient
    {
        Task<string> GetAuthenticationRealm(Uri target);
        Task<SharePointContextUser> GetSharePointContextUser(Uri target, string accessToken);
    }
}