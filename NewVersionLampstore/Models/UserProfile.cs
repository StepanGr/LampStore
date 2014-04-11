using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.ComponentModel.DataAnnotations;

namespace NewVersionLampstore.Models
{
    public class UserProfile
    {
        private ProfileBase profile = null;

        public UserProfile(string username)
        {
            profile = ProfileBase.Create(username);
        }
        [Display(Name = "Имя")]
        public string FirstName
        {
            get
            {
                if (profile == null) return string.Empty;
                else return profile[Constants.PROFILE_FIRST_NAME] as string;
            }
            set { if (profile != null) { profile[Constants.PROFILE_FIRST_NAME] = value; } }
        }

        [Display(Name = "Фамилия")]
        public string LastName
        {
            get
            {
                if (profile == null) return string.Empty;
                else return profile[Constants.PROFILE_LAST_NAME] as string;
            }
            set { if (profile != null) { profile[Constants.PROFILE_LAST_NAME] = value; } }
        }
        [Display(Name = "Телефон")]
        public string Phone
        {
            get
            {
                if (profile == null) return string.Empty;
                else return profile[Constants.PROFILE_PHONE] as string;
            }
            set { if (profile != null) { profile[Constants.PROFILE_PHONE] = value; } }
        }

        [Display(Name = "Адрес")]
        public string Address
        {
            get
            {
                if (profile == null) return string.Empty;
                else return profile[Constants.PROFILE_ADDRESS] as string;
            }
            set { if (profile != null) { profile[Constants.PROFILE_ADDRESS] = value; } }
        }

        public void Save() { if (profile != null)profile.Save(); }
    }
}