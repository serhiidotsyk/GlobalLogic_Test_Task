using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GlobalLogic_Test_Task.Models
{
    public class MyTreeHelper<T>
    {
        private readonly T _value;
        private readonly List<MyTreeHelper<T>> _children = new List<MyTreeHelper<T>>();
        public MyTreeHelper(T value)
        {
            _value = value;
        }

        public MyTreeHelper<T> this[int i]
        {
            get { return _children[i]; }
        }

        public MyTreeHelper<T> Parent { get; private set; }

        public T Value { get { return _value; } }

        public ReadOnlyCollection<MyTreeHelper<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }

        public MyTreeHelper<T> AddChild(T value)
        {
            var node = new MyTreeHelper<T>(value) { Parent = this };
            _children.Add(node);
            return node;
        }

        public MyTreeHelper<T>[] AddChildren(params T[] values)
        {
            return values.Select(AddChild).ToArray();
        }

        public bool RemoveChild(MyTreeHelper<T> node)
        {
            return _children.Remove(node);
        }

        public void Traverse(Action<T> action)
        {
            action(Value);
            foreach (var child in _children)
                child.Traverse(action);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Concat(_children.SelectMany(x => x.Flatten()));
        }
    }
}
