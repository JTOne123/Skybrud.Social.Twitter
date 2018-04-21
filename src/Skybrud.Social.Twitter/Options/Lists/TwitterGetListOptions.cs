﻿using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a request to the Twitter API for getting a information about a Twitter list.
    /// </summary>
    public class TwitterGetListOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the list.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the slug of the list.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the ID of the owning user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the owning user.
        /// </summary>
        public string ScreenName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterGetListOptions() { }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="listId"/>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        public TwitterGetListOptions(long listId) : this() {
            Id = listId;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="userId">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        public TwitterGetListOptions(long userId, string slug) : this() {
            UserId = userId;
            Slug = slug;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        public TwitterGetListOptions(string screenName, string slug) : this() {
            ScreenName = screenName;
            Slug = slug;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString qs = new SocialHttpQueryString();
            if (Id > 0) qs.Set("list_id", UserId);
            if (!String.IsNullOrWhiteSpace(Slug)) qs.Set("slug", Slug);
            if (UserId > 0) qs.Set("owner_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("owner_screen_name", ScreenName);
            return qs;
        }

        #endregion

    }

}