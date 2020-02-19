using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GlobalLogic_Test_Task.Models
{
    public class MyTreeHelper<T>
    {
        private readonly List<MyTreeHelper<T>> _children = new List<MyTreeHelper<T>>();
        public MyTreeHelper(T value)
        {
            Value = value;
        }

        public MyTreeHelper<T> Parent { get; private set; }

        public T Value { get; }

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

        public bool RemoveChild(MyTreeHelper<T> node)
        {
            return _children.Remove(node);
        }
    }
}
