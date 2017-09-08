using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookEventAdapter : Adapter, IHavePicture, IAttendable
    {
        private Event m_Event;
        public DateTime? Date
        {
            get { return m_Event.StartTime; }
        }

        public override string ID
        {
            get { return m_Event.Id; }
        }

        public override string Name
        {
            get { return m_Event.Name; }
        }

        public override string Description
        {
            get { return m_Event.Description; }
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
            return this.m_Event.PictureNormalURL;
        }

        public void Attend(string i_Option)
        {
            if(i_Option=="Attending")
            {
                m_Event.Respond(Event.eRsvpType.Attending);
            }
            else if(i_Option=="Maybe")
            {
                m_Event.Respond(Event.eRsvpType.Maybe);
            }
            else if(i_Option=="Not Attending")
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
