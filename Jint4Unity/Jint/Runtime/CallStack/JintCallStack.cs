namespace Jint.Runtime.CallStack
{
    using System.Collections.Generic;
    using System.Linq;

    public class JintCallStack
    {
        private Stack<CallStackElement> _stack = new Stack<CallStackElement>();

        private Dictionary<CallStackElement, int> _statistics =
            new Dictionary<CallStackElement, int>(new CallStackElementComparer());

        public int Push(CallStackElement item)
        {
            _stack.Push(item);
            if (_statistics.ContainsKey(item))
            {
                return ++_statistics[item];
            }
            else
            {
                _statistics.Add(item, 0);
                return 0;
            }
        }

        public CallStackElement Pop()
        {
            var item = _stack.Pop();
            if (_statistics[item] == 0)
            {
                _statistics.Remove(item);
            }
            else
            {
                _statistics[item]--;
            }

            return item;
        }

        public void Clear()
        {
            _stack.Clear();
            _statistics.Clear();
        }

        public override string ToString()
        {
            var iterator = _stack.Select(cse => cse.ToString()).Reverse();
            var list = new List<string>();
            foreach (var item in iterator)
            {
                list.Add(item);
            }
            return string.Join("->", list.ToArray());
        }
    }
}
