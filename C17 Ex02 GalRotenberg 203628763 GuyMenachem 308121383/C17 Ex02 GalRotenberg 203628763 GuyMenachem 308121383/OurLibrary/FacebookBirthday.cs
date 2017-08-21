using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookBirthday
    {
        public DateTime Date { get; private set; }

        public FacebookFriend Celebrator { get; private set; }

        public FacebookBirthday(FacebookFriend i_friend, string i_Birthday)
        {
            Celebrator = i_friend;
            Date = GetBirthdayDate(i_Birthday);
        }

        private DateTime GetBirthdayDate(string i_Birthday)
        {
            int year, month, day;
            string[] parser = i_Birthday.Split('/');

            month = int.Parse(parser[0]);
            day = int.Parse(parser[1]);
            year = int.Parse(parser[2]);

            DateTime rslt = new DateTime(year, month, day);

            return rslt;
        }

        public override string ToString()
        {
            return Celebrator.Name;
        }
    }
}
