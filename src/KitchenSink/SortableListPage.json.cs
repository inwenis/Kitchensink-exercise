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

        void Handle(Input.ButtonDown action)
        {
            var sortableListPage = (SortableListPage)Parent.Parent;
            sortableListPage.MoveDown(Data);
        }
    }

    partial class SortableListPage : Json
    {
        public void MoveUp(Person person)
        {
            if (person.Position == 0) return;
            ChangePosition(person, -1);
            Transaction.Commit();
            ReorderPeopleList();
        }

        public void MoveDown(Person person)
        {
            if (person.Position == People.Count - 1) return;
            ChangePosition(person, +1);
            Transaction.Commit();
            ReorderPeopleList();
        }

        private void ChangePosition(Person person, int changePositionBy)
        {
            var oldPosition = person.Position;
            var newPosition = person.Position + changePositionBy;
            var currentPersonOnNewPosition = People.Single(p => p.Position == newPosition);
            person.Position = newPosition;
            currentPersonOnNewPosition.Position = oldPosition;
        }

        private void ReorderPeopleList()
        {
            var orderedPeople = People.OrderBy(p => p.Position).ToArray();
            People.Clear();
            foreach (var person in orderedPeople)
            {
                People.Add(person);
            }
        }
    }
}