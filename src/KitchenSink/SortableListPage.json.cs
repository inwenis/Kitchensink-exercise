using System.Linq;
using Starcounter;

namespace KitchenSink
{
    [Database]
    public class Person
    {
        public int Position;
        public string Name;
    }

    [SortableListPage_json.People]
    partial class SortableListPagePeopleElement: Json, IBound<Person>
    {
        void Handle(Input.ButtonUp action)
        {
            var sortableListPage = (SortableListPage)Parent.Parent;
            sortableListPage.MoveUp(Data);
        }
    }

    partial class SortableListPage : Json
    {
        public void MoveUp(Person person)
        {
            if (person.Position == 0) return;

            var oldPosition = person.Position;
            var newPosition = person.Position - 1;
            var currentPersonOnNewPosition = People.Single(p => p.Position == newPosition);

            person.Position = newPosition;
            currentPersonOnNewPosition.Position = oldPosition;

            Transaction.Commit();

            var orderedPeople = People.OrderBy(p => p.Position).ToArray();
            People.Clear();
            foreach (var p in orderedPeople)
            {
                this.People.Add(p);
            }
        }
    }
}