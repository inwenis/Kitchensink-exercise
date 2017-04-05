using System.Collections.Generic;
using System.Linq;
using Starcounter;

namespace KitchenSink
{
    [Database]
    public class Person
    {
        public int Position;
        public string Name;
//        public QueryResultRows<Expense> Spendings => Db.SQL<Expense>("SELECT e FROM Expense e WHERE e.Spender = ?", this);
//        public decimal CurrentBalance => Db.SQL<decimal>("SELECT SUM(e.Amount) FROM Expense e WHERE e.Spender = ?", this).First;
    }

    //BreadcrumbPageBreadcrumbsElement

    [SortableListPage_json.People]
    partial class SortableListPagePeopleElement: Json, IBound<Person>
    {
        void Handle(Input.ButtonUp action)
        {
            Data.Name = "winner";

            var sortableListPage = (SortableListPage) Parent.Parent;
            sortableListPage.MoveUp(Data);

            //if i am not top
            //my position ++
            //get the guy above me
            //his position --

            Transaction.Commit();
        }
    }

    partial class SortableListPage : Json
    {
        public void SetActiveItem(TreeItem treeItem, bool isAdd = false)
        {
//            RebuildBreadcrumb(treeItem, isAdd);
//            CurrentTreeItem.Data = treeItem;
//            CurrentTreeItem.IsAdd = isAdd;
//            CurrentTreeItem.ParentName = treeItem.Parent.Name;
        }

        public void MoveUp(Person person)
        {
            var newPos = person.Position-1;
            var theOtherOne = this.People.Single(x => x.Position == newPos);

            person.Position--;
            theOtherOne.Position++;

            Transaction.Commit();
            var ordered = this.People.OrderBy(p => p.Position).ToArray();
            this.People.Clear();
            foreach (var p in ordered)
            {
                this.People.Add(p);
            }
        }


        void Handle(Input.SaveTrigger action)
        {
            
            this.People[0].Name = "aaaa";
            Transaction.Commit();
        }

//        void Handle(Input.CancelTrigger action)
//        {
//            Transaction.Rollback();
//            RefreshExpenses(this.Data.Spendings);
//        }

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

//        protected override void OnData()
//        {
//            base.OnData();
//
//            //TablePage.PetsElementJson pet;
//            SortableListPage.PeopleElementJson person;
//
//            person = this.People.Add();
//            person.Id = 1;
//            person.Name = "Filip";
//            person.ButtonUp = 0;
//            person.ButtonDown = 0;
//
//            person = this.People.Add();
//            person.Id = 2;
//            person.Name = "Mietek";
//            person.ButtonUp = 0;
//            person.ButtonDown = 0;
//
//            person = this.People.Add();
//            person.Id = 3;
//            person.Name = "Zbyszek";
//            person.ButtonUp = 0;
//            person.ButtonDown = 0;
//
//            person = this.People.Add();
//            person.Id = 4;
//            person.Name = "Ada";
//            person.ButtonUp = 0;
//            person.ButtonDown = 0;
//
//            person = this.People.Add();
//            person.Id = 5;
//            person.Name = "Klara";
//            person.ButtonUp = 0;
//            person.ButtonDown = 0;
//        }

        public void ReOrder()
        {
            //var guyToBeMoved = this.People.Single(p => p.ButtonUp == 1 || //p.ButtonDown == 1);
            //var indexOfGuyToBeMoved = this.People.IndexOf(guyToBeMoved);
            //if (guyToBeMoved.ButtonUp == 1)
            //{
            //    if (indexOfGuyToBeMoved == 0)
            //    {
            //        //nothing to do
            //    }
            //    else
            //    {
            //        guyToBeMoved.Position--;
            //        People.ElementAt(indexOfGuyToBeMoved - 1).Position++;
            //    }
            //    guyToBeMoved.ButtonUp = 0;
            //}
            //else //if (guyToBeMoved.ButtonDown == 1)
            //{
            //    if (indexOfGuyToBeMoved == this.People.Count - 1)
            //    {
            //        //nothing to do
            //    }
            //    else
            //    {
            //        guyToBeMoved.Position++;
            //        People.ElementAt(indexOfGuyToBeMoved + 1).Position--;
            //    }
            //    guyToBeMoved.ButtonDown = 0;
            //}
            //Transaction.Commit();
        }

        //        public Arr<Json> SortedPeople
        //        {
        //            get
        //            {
        ////                if (this.People.Any(p=> p.ButtonUp == 1 || p.ButtonDown == 1))
        ////                {
        ////                    ReOrder();
        ////                }
        //
        //                //var tempCopy = People.ToList();
        //                //People.Clear();
        //                //foreach (var peopleElementJson in tempCopy.OrderBy(p => //p.Position))
        //                //{
        //                //    People.Add(peopleElementJson);
        //                //}
        //
        //                return this.People;
        //            }
        //        }

        
    }
}