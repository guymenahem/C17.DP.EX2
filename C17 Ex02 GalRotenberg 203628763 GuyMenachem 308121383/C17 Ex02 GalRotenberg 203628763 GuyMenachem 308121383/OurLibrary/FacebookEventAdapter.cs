using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookEventAdapter : IFacebookAdapter, IHavePicture, IAttendable
    {
        private Event m_Event;

        private Event OriginalEvent
        {
            get
            {
                return this.m_Event;
            }
        }

        public DateTime? Date
        {
            get { return m_Event.StartTime; }
        }

        public string ID
        {
            get { return this.OriginalEvent.Id; }
        }

        public string Name
        {
            get { return this.OriginalEvent.Name; }
        }

        public string Description
        {
            get { return this.OriginalEvent.Description; }
        }

        public FacebookEventAdapter(Event i_Event)
        {
            m_Event = i_Event;
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetPicture()
        {
            return this.OriginalEvent.PictureNormalURL;
        }

        public void Attend(string i_Option)
        {
            if(i_Option == "Attending")
            {
                m_Event.Respond(Event.eRsvpType.Attending);
            }
            else if(i_Option == "Maybe")
            {
                m_Event.Respond(Event.eRsvpType.Maybe);
            }
            else if(i_Option == "Not Attending")
            {
                m_Event.Respond(Event.eRsvpType.Declined);
            }
            else
            {
                throw new ArgumentException("Selected attending option does not exist.");
            }
        }
    }
}
