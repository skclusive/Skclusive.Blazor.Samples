using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.Blazor.TodoApp.Models;
using static Skclusive.Blazor.TodoApp.Models.AppTypes;

namespace Skclusive.Blazor.TodoApp.Tests
{
    public class TestAppState
    {
        [Fact]
        public void TestStore()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" }
                }
            });

            Assert.NotNull(store);

            Assert.Equal(Filter.All, store.Filter);

            Assert.Equal("Get coffee", store.Todos[0].Title);

            store.Todos[0].Edit("Get Filter Coffee");

            Assert.Equal("Get Filter Coffee", store.Todos[0].Title);

            store.Todos[0].Toggle();

            Assert.True(store.Todos[0].Done);

            store.Todos[0].Remove();

            Assert.Empty(store.Todos);

            Assert.Equal(0, store.TotalCount);
        }

        [Fact]
        public void TestTodoCounts()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee", Done = true },

                    new TodoSnapshot { Title = "Learn Blazor" }
                }
            });

            Assert.Equal(2, store.FilteredTodos.Count);

            Assert.Equal(2, store.TotalCount);

            Assert.Equal(1, store.ActiveCount);

            Assert.Equal(1, store.CompletedCount);

            store.Todos[1].Toggle();

            Assert.Equal(2, store.FilteredTodos.Count);

            store.SetFilter(Filter.Active);

            Assert.Equal(Filter.Active, store.Filter);

            Assert.Equal(0, store.FilteredTodos.Count);

            store.SetFilter(Filter.Completed);

            Assert.Equal(Filter.Completed, store.Filter);

            Assert.Equal(2, store.FilteredTodos.Count);

            Assert.Equal(0, store.ActiveCount);

            Assert.Equal(2, store.CompletedCount);
        }

        [Fact]
        public void TestTodoCompleteAll()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" },

                    new TodoSnapshot { Title = "Learn Blazor" }
                }
            });

            Assert.Equal(2, store.FilteredTodos.Count);

            Assert.Equal(2, store.ActiveCount);

            Assert.Equal(0, store.CompletedCount);

            store.CompleteAll();

            store.SetFilter(Filter.Completed);

            Assert.Equal(Filter.Completed, store.Filter);

            Assert.Equal(2, store.FilteredTodos.Count);

            Assert.Equal(0, store.ActiveCount);

            Assert.Equal(2, store.CompletedCount);
        }

        [Fact]
        public void TestTodoClearCompleted()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" },

                    new TodoSnapshot { Title = "Learn Blazor" }
                }
            });

            Assert.Equal(2, store.FilteredTodos.Count);

            Assert.Equal(2, store.ActiveCount);

            Assert.Equal(0, store.CompletedCount);

            store.Todos[0].Toggle();

            Assert.Equal(1, store.ActiveCount);

            Assert.Equal(1, store.CompletedCount);

            store.ClearCompleted();

            Assert.Equal(1, store.FilteredTodos.Count);

            Assert.Equal(1, store.ActiveCount);

            Assert.Equal(0, store.CompletedCount);

            Assert.Equal("Learn Blazor", store.Todos[0].Title);
        }

        [Fact]
        public void TestAddTodo()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" }
                }
            });

            Assert.Equal(1, store.TotalCount);

            store.AddTodo("Learn Blazor");

            Assert.Equal(2, store.TotalCount);

            Assert.Equal("Learn Blazor", store.Todos[0].Title);

            Assert.Equal("Get coffee", store.Todos[1].Title);
        }

        [Fact]
        public void TestEditTodo()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" }
                }
            });

            Assert.Equal("Get coffee", store.Todos[0].Title);

            store.Todos[0].Edit("Learn Blazor");

            Assert.Equal(1, store.TotalCount);

            Assert.Equal("Learn Blazor", store.Todos[0].Title);

            store.Todos[0].Edit("Learn Blazor");

            Assert.Equal("Learn Blazor", store.Todos[0].Title);
        }

        [Fact]
        public void TestNoEditTodo()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" }
                }
            });

            Assert.Equal("Get coffee", store.Todos[0].Title);

            store.Todos[0].Edit("Learn Blazor");

            store.Todos[0].Edit("Learn Blazor");

            Assert.Equal("Learn Blazor", store.Todos[0].Title);
        }

        [Fact]
        public void TestOnAction()
        {
            var store = TodoType.Create(new TodoSnapshot { Title = "Get coffee" });

            var list = new List<string>();

            store.OnAction((ISerializedActionCall call) =>
            {
                var snapshot = store.GetSnapshot<TodoSnapshot>();

                list.Add(snapshot.Title);
            });

            store.Edit("Learn Blazor");

            Assert.Single(list);

            Assert.Equal("Learn Blazor", list[0]);
        }

        [Fact]
        public void TestOnAction2()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                   new TodoSnapshot { Title = "Get coffee" }
                }
            });

            var list = new List<int>();

            store.OnAction((ISerializedActionCall call) =>
            {
                var snapshot = store.GetSnapshot<AppStateSnapshot>();

                list.Add(snapshot.Todos.Length);
            });

            store.AddTodo("Learn Blazor");

            Assert.Single(list);

            Assert.Equal(2, list[0]);
        }

        [Fact]
        public void TestOnAction3()
        {
            var store = AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new ITodoSnapshot[]
                {
                   new TodoSnapshot { Title = "Get coffee" }
                }
            });

            var list = new List<(int, string)>();

            store.OnAction((ISerializedActionCall call) =>
            {
                var snapshot = store.GetSnapshot<AppStateSnapshot>();

                list.Add((snapshot.Todos.Length, snapshot.Todos[0].Title));
            });

            store.Todos[0].Edit("Learn Blazor");

            Assert.Single(list);

            Assert.Equal(1, list[0].Item1);
            Assert.Equal("Learn Blazor", list[0].Item2);
        }

        [Fact]
        public void TestOnAction4()
        {
            var list = TodoListType.Create(new ITodoSnapshot[]
            {
                new TodoSnapshot { Title = "Get coffee" }
            });

            list.Unprotected();

            list.Insert(0, TodoType.Create(new TodoSnapshot { Title = "Learn Blazor" }));

            var snapshots = list.GetSnapshot<ITodoSnapshot[]>();

            Assert.Equal(2, snapshots.Length);
        }
    }
}
