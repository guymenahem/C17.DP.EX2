using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C17_Ex01_Gal_203628763_Guy_308121383
{
    class ListBoxLoadObserver<T> : ILoadObserver
    {
        public ListBox ListBox { get; set; }
        public Func<ICollection<T>> LoadFunction {get; set;}

        public void LoadNotify()
        {
            Thread thread = new Thread(this.Load) { IsBackground = true };
            thread.Start();
        }

        public void UnLoadNotify()
        {
            this.ListBox.Items.Clear();
        }

        public void Load()
        {
            foreach(T item in LoadFunction.Invoke())
            {
                this.ListBox.Invoke(new Action(() => this.ListBox.Items.Add(item)));
            }
        }
    }
}
