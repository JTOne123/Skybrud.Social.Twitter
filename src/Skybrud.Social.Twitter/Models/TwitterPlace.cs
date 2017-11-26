using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models {

    public class TwitterPlace : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the place.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the URL for the place in the Twitter API.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the type of the place.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the name of the place.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the full name of the place.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets the country code of the place.
        /// </summary>
        public string CountryCode { get; private set; }

        /// <summary>
        /// Gets the country name of the place.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Gets the bounding box describing the place.
        /// </summary>
        public TwitterBoundingBox BoundingBox { get; private set; }

        #endregion

        #region Constructors

        private TwitterPlace(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Url = obj.GetString("url");
            Type = obj.GetString("place_type");
            Name = obj.GetString("name");
            FullName = obj.GetString("full_name");
            CountryCode = obj.GetString("country_code");
            Country = obj.GetString("country");
            BoundingBox = obj.GetObject("bounding_box", TwitterBoundingBox.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterPlace</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static TwitterPlace Parse(JObject obj) {
            return obj == null ? null : new TwitterPlace(obj);
        }

        #endregion

    }

}