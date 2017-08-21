using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookEvent : IHavePicture
    {
        public DateTime? Date { get; private set; }

        public string Name { get; private set; }

        public string ID { get; private set; }

        public string Description { get; private set; }

        public FacebookPicture Image { get; private set; }

        public FacebookEvent(Event i_Event)
        {
            this.Date = i_Event.StartTime;
            this.Name = i_Event.Name;
            this.ID = i_Event.Id;
            this.Description = i_Event.Description;
            this.Image = new FacebookPicture(i_Event.PictureLargeURL);
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetPicture()
        {
            return this.Image.URL;
        }
    }
}
