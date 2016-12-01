﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterUserCollection : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the array with the users returned in the response.
        /// </summary>
        public TwitterUser[] Users { get; private set; }

        /// <summary>
        /// Gets the cursor pointing to the next page in the result set.
        /// </summary>
        public long NextCursor { get; private set; }

        /// <summary>
        /// Gets the cursor pointing to the previous page in the result set.
        /// </summary>
        public long PreviousCursor { get; private set; }

        #endregion

        #region Constructors

        private TwitterUserCollection(JObject obj) : base(obj) {
            Users = obj.GetArray("users", TwitterUser.Parse);
            NextCursor = obj.GetInt64("next_cursor");
            PreviousCursor = obj.GetInt64("previous_cursor");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterUserCollection</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static TwitterUserCollection Parse(JObject obj) {
            return obj == null ? null : new TwitterUserCollection(obj);
        }

        #endregion
    
    }

}