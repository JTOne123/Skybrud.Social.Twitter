using System;
using Skybrud.Social.Http;
using Skybrud.Social.Twitter.Models.Statuses;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Statuses;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Statuses</strong> endpoint.
    /// </summary>
    public class TwitterStatusesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterStatusesRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        #region GetStatusMessage(...)

        /// <summary>
        /// Gets information about the status message (tweet) with the <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-show-id</cref>
        /// </see>
        public SocialHttpResponse GetStatusMessage(long statusId) {
            return GetStatusMessage(new TwitterGetStatusMessageOptions(statusId));
        }

        /// <summary>
        /// Gets the raw API response for a status message (tweet) matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-show-id</cref>
        /// </see>
        public SocialHttpResponse GetStatusMessage(TwitterGetStatusMessageOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/show.json", options);
        }

        #endregion

        #region PostStatusMessage(...)

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public SocialHttpResponse PostStatusMessage(string status) {
            return PostStatusMessage(new TwitterPostStatusMessageOptions { Status = status });
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public SocialHttpResponse PostStatusMessage(string status, long? replyTo) {
            return PostStatusMessage(new TwitterPostStatusMessageOptions { Status = status, ReplyTo = replyTo });
        }

        /// <summary>
        /// Posts a new status message (tweet) with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-update</cref>
        /// </see>
        public SocialHttpResponse PostStatusMessage(TwitterPostStatusMessageOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpPostRequest("https://api.twitter.com/1.1/statuses/update.json", options);
        }

        #endregion

        #region GetUserTimeline(...)

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(long userId) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(userId));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(long userId, int count) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(userId, count));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(string screenName) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(screenName));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(string screenName, int count) {
            return GetUserTimeline(new TwitterGetUserTimelineOptions(screenName, count));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(TwitterGetUserTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/user_timeline.json", options);
        }

        #endregion

        #region GetHomeTimeline(...)

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public SocialHttpResponse GetHomeTimeline() {
            return GetHomeTimeline(new TwitterGetHomeTimelineOptions());
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public SocialHttpResponse GetHomeTimeline(int count) {
            return GetHomeTimeline(new TwitterGetHomeTimelineOptions(count));
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow. 
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-home_timeline</cref>
        /// </see>
        public SocialHttpResponse GetHomeTimeline(TwitterGetHomeTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/home_timeline.json", options);
        }

        #endregion

        #region GetMentionsTimeline(...)

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public SocialHttpResponse GetMentionsTimeline() {
            return GetMentionsTimeline(new TwitterGetMentionsTimelineOptions());
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public SocialHttpResponse GetMentionsTimeline(int count) {
            return GetMentionsTimeline(new TwitterGetMentionsTimelineOptions(count));
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/timelines/api-reference/get-statuses-mentions_timeline</cref>
        /// </see>
        public SocialHttpResponse GetMentionsTimeline(TwitterGetMentionsTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/mentions_timeline.json", options);
        }

        #endregion

        #region GetRetweetsOfMe(...)

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public SocialHttpResponse GetRetweetsOfMe() {
            return GetRetweetsOfMe(new TwitterGetRetweetsOfMeTimelineOptions());
        }

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public SocialHttpResponse GetRetweetsOfMe(int count) {
            return GetRetweetsOfMe(new TwitterGetRetweetsOfMeTimelineOptions(count));
        }

        /// <summary>
        /// Gets a list of the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets_of_me</cref>
        /// </see>
        public SocialHttpResponse GetRetweetsOfMe(TwitterGetRetweetsOfMeTimelineOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/retweets_of_me.json", options);
        }

        #endregion

        #region RetweetStatusMessage(...)

        /// <summary>
        /// Retweets the status message with the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be retweeted.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-retweet-id</cref>
        /// </see>
        public SocialHttpResponse RetweetStatusMessage(long statusId) {
            return RetweetStatusMessage(statusId, false);
        }

        /// <summary>
        /// Retweets the status message with the specified <paramref name="statusId"/>.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be retweeted.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-retweet-id</cref>
        /// </see>
        public SocialHttpResponse RetweetStatusMessage(long statusId, bool trimUser) {
            return Client.DoHttpPostRequest("https://api.twitter.com/1.1/statuses/retweet/" + statusId + ".json" + (trimUser ? "?trim_user=true" : ""));
        }

        /// <summary>
        /// Retweets the specified <paramref name="statusMessage"/>.
        /// </summary>
        /// <param name="statusMessage">The status message to be retweeted.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse RetweetStatusMessage(TwitterStatusMessage statusMessage) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return RetweetStatusMessage(statusMessage.Id, false);
        }

        /// <summary>
        /// Retweets the specified <paramref name="statusMessage"/>.
        /// </summary>
        /// <param name="statusMessage">The status message to be retweeted.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse RetweetStatusMessage(TwitterStatusMessage statusMessage, bool trimUser) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return RetweetStatusMessage(statusMessage.Id, trimUser);
        }

        #endregion

        #region DestroyStatusMessage(...)

        /// <summary>
        /// Destroys the status message with the specified <paramref name="statusId"/>. The authenticating user must be
        /// the author of the specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be destroyed.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-destroy-id</cref>
        /// </see>
        public SocialHttpResponse DestroyStatusMessage(long statusId) {
            return DestroyStatusMessage(statusId, false);
        }

        /// <summary>
        /// Destroys the status message with the specified <paramref name="statusId"/>. The authenticating user must be
        /// the author of the specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusId">The ID of the status message to be destroyed.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/post-statuses-destroy-id</cref>
        /// </see>
        public SocialHttpResponse DestroyStatusMessage(long statusId, bool trimUser) {
            return Client.DoHttpPostRequest("https://api.twitter.com/1.1/statuses/destroy/" + statusId + ".json" + (trimUser ? "?trim_user=true" : ""));
        }

        /// <summary>
        /// Destroys the specified <paramref name="statusMessage"/>. The authenticating user must be the author of the
        /// specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusMessage">The status meessage to be destroyed.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse DestroyStatusMessage(TwitterStatusMessage statusMessage) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return DestroyStatusMessage(statusMessage.Id, false);
        }

        /// <summary>
        /// Destroys the specified <paramref name="statusMessage"/>. The authenticating user must be the author of the
        /// specified status message. Returns the destroyed status message if successful.
        /// </summary>
        /// <param name="statusMessage">The status meessage to be destroyed.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse DestroyStatusMessage(TwitterStatusMessage statusMessage, bool trimUser) {
            if (statusMessage == null) throw new ArgumentNullException(nameof(statusMessage));
            return DestroyStatusMessage(statusMessage.Id, trimUser);
        }

        #endregion

        #endregion

    }

}