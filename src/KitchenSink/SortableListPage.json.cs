using System.Linq;
using Starcounter;

namespace KitchenSink
{
    partial class SortableListPage : Json
    {
        public string DoSomeOpetarions
        {
            get
            {
                if (string.IsNullOrEmpty(XYZInput))
                {
                    return "XYZ is null or empty";
                }
                return "not empty";
            }
        }

        protected override void OnData()
        {
            base.OnData();

            //TablePage.PetsElementJson pet;
            SortableListPage.PeopleElementJson person;

            person = this.People.Add();
            person.Id = 1;
            person.Name = "Filip";
            person.ButtonUp = 0;
            person.ButtonDown = 0;

            person = this.People.Add();
            person.Id = 2;
            person.Name = "Mietek";
            person.ButtonUp = 0;
            person.ButtonDown = 0;

            person = this.People.Add();
            person.Id = 3;
            person.Name = "Zbyszek";
            person.ButtonUp = 0;
            person.ButtonDown = 0;

            person = this.People.Add();
            person.Id = 4;
            person.Name = "Ada";
            person.ButtonUp = 0;
            person.ButtonDown = 0;

            person = this.People.Add();
            person.Id = 5;
            person.Name = "Klara";
            person.ButtonUp = 0;
            person.ButtonDown = 0;
        }

        public void ReOrder()
        {
            var guyToBeMoved = this.People.Single(p => p.ButtonUp == 1 || p.ButtonDown == 1);
            var indexOfGuyToBeMoved = this.People.IndexOf(guyToBeMoved);
            if (guyToBeMoved.ButtonUp == 1)
            {
                if (indexOfGuyToBeMoved == 0)
                {
                    //nothing to do
                }
                else
                {
                    var moveTo = indexOfGuyToBeMoved - 1;
                    this.People.Remove(guyToBeMoved);
                    this.People.Insert(moveTo, guyToBeMoved);
                }
                guyToBeMoved.ButtonUp = 0;
            }
            else //if (guyToBeMoved.ButtonDown == 1)
            {
                if (indexOfGuyToBeMoved == this.People.Count - 1)
                {
                    //nothing to do
                }
                else
                {
                    var moveTo = indexOfGuyToBeMoved + 1;
                    this.People.Remove(guyToBeMoved);
                    this.People.Insert(moveTo, guyToBeMoved);
                }
                guyToBeMoved.ButtonDown = 0;
            }
            
        }

        public Arr<PeopleElementJson> SortedPeople
        {
            get
            {
                if (this.People.Any(p=> p.ButtonUp == 1 || p.ButtonDown == 1))
                {
                    ReOrder();
                }
                return People;
            }
        }
    }
}