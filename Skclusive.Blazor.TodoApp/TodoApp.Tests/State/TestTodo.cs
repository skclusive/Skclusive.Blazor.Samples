using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.Blazor.TodoApp.Models;
using static Skclusive.Blazor.TodoApp.Models.AppTypes;

namespace Skclusive.Blazor.TodoApp.Tests
{
    public class TestTodo
    {
        [Fact]
        public void TestCreateTodo()
        {
            var todo = TodoType.Create(new TodoSnapshot { Title = "Get coffee" });

            Assert.Equal("Get coffee", todo.Title);
        }

        [Fact]
        public void TestEditTodo()
        {
            var todo = TodoType.Create(new TodoSnapshot { Title = "Get coffee" });

            Assert.Equal("Get coffee", todo.Title);

            todo.Edit("Learn Blazor");

            Assert.Equal("Learn Blazor", todo.Title);

            todo.Edit("Learn Blazor");

            Assert.Equal("Learn Blazor", todo.Title);
        }

        [Fact]
        public void TestNoEditTodo()
        {
            var todo = TodoType.Create(new TodoSnapshot { Title = "Get coffee" });

            Assert.Equal("Get coffee", todo.Title);

            todo.Edit("Learn Blazor");

            todo.Edit("Learn Blazor");

            Assert.Equal("Learn Blazor", todo.Title);
        }

        [Fact]
        public void TestOnAction()
        {
            var todo = TodoType.Create(new TodoSnapshot { Title = "Get coffee" });

            var list = new List<string>();

            todo.OnAction((ISerializedActionCall call) =>
            {
                var snapshot = todo.GetSnapshot<TodoSnapshot>();

                list.Add(snapshot.Title);
            });

            todo.Edit("Learn Blazor");

            Assert.Single(list);

            Assert.Equal("Learn Blazor", list[0]);
        }
    }
}
