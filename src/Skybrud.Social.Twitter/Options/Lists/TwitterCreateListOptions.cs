﻿using System;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Twitter.Models.Lists;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a call to the Twitter API for creating a new list.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-create</cref>
    /// </see>
    public class TwitterCreateListOptions : IHttpPostOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the name for the list. A list’s name must start with a letter and can consist only of 25 or
        /// fewer letters, numbers, <code>-</code>, or <code>_</code> characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the list will be public or private. Values can be <see cref="TwitterListMode.Public"/>
        /// or <see cref="TwitterListMode.Private"/>. Default is <see cref="TwitterListMode.Public"/>.
        /// </summary>
        public TwitterListMode Mode { get; set; }


        /// <summary>
        /// Gets or sets the description to give the list.
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterCreateListOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name for the list. A list’s name must start with a letter and can consist only of 25
        /// or fewer letters, numbers, <code>-</code>, or <code>_</code> characters.</param>
        public TwitterCreateListOptions(string name) {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="name"/> and <paramref name="mode"/>.
        /// </summary>
        /// <param name="name">The name for the list. A list’s name must start with a letter and can consist only of 25
        /// or fewer letters, numbers, <code>-</code>, or <code>_</code> characters.</param>
        /// <param name="mode">Whether the list will be public or private. Values can be
        /// <see cref="TwitterListMode.Public"/> or <see cref="TwitterListMode.Private"/>.</param>
        public TwitterCreateListOptions(string name, TwitterListMode mode) {
            Name = name;
            Mode = mode;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="name"/>, <paramref name="mode"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="name">The name for the list. A list’s name must start with a letter and can consist only of 25
        /// or fewer letters, numbers, <code>-</code>, or <code>_</code> characters.</param>
        /// <param name="mode">Whether the list will be public or private. Values can be
        /// <see cref="TwitterListMode.Public"/> or <see cref="TwitterListMode.Private"/>.</param>
        /// <param name="description">The description to give the list.</param>
        public TwitterCreateListOptions(string name, TwitterListMode mode, string description) {
            Name = name;
            Mode = mode;
            Description = description;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            return new SocialHttpQueryString();
        }

        public IHttpPostData GetPostData() {

            if (String.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException(nameof(Name));

            SocialHttpPostData data = new SocialHttpPostData();

            data.Add("name", Name);
            data.Add("mode", StringUtils.ToCamelCase(Mode));
            if (!String.IsNullOrWhiteSpace(Description)) data.Add("description", Description);

            return data;

        }

        #endregion

    }

}