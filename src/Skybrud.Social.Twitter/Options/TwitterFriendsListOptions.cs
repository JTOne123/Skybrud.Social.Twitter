using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterFriendsListOptions : IGetOptions {

        #region Constants

        public const int DefaultCursor = -1;
        public const int DefaultCount = 20;
        public const bool DefaultSkipStatus = false;
        public const bool DefaultIncludeUserEntities = true;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user for whom to return results for.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the user for whom to return results for.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Causes the results to be broken into pages. If no cursor is provided, a value of <code>-1</code> will be
        /// assumed, which is the first "page".
        /// 
        /// The response from the API will include a <code>previous_cursor</code> and <code>next_cursor</code> to allow
        /// paging back and forth.
        /// </summary>
        public long Cursor { get; set; }

        /// <summary>
        /// The number of users to return per page, up to a maximum of 200. Defaults to 20.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// When set to <code>true</code> statuses will not be included in the returned user objects.
        /// </summary>
        public bool SkipStatus { get; set; }

        /// <summary>
        /// The user object entities node will be disincluded when set to <code>false</code>.
        /// </summary>
        public bool IncludeUserEntities { get; set; }
        
        #endregion

        #region Constructors

        public TwitterFriendsListOptions() {
            Cursor = DefaultCursor;
            Count = DefaultCount;
            SkipStatus = DefaultSkipStatus;
            IncludeUserEntities = DefaultIncludeUserEntities;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (Cursor != DefaultCursor) qs.Set("cursor", Cursor);
            if (Count != DefaultCount) qs.Set("count", Count);
            if (SkipStatus != DefaultSkipStatus) qs.Set("skip_status", SkipStatus ? "1" : "0");
            if (IncludeUserEntities != DefaultIncludeUserEntities) qs.Set("include_user_entities", IncludeUserEntities ? "1" : "0");
            return qs;
        }

        #endregion

    }

}