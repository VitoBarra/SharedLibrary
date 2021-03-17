using System;
using System.Linq;
using System.Collections.Generic;

namespace Helper.Dictionary
{
    public class DictionaryHelper<T>
    {
        private IList<T> _keys = new List<T>();
        public IList<T> Keys { get => _keys; protected set { _keys = value; } }
        public T CurrentKey
        {
            get => Keys[Index]; set
            {
                if (IsPresentKey(value))
                    Index = Keys.IndexOf(value);
            }
        }
        public T Head { get => Keys[0]; }
        public T Tail { get => Keys[Keys.Count - 1]; }

        protected int _index = -1;
        public virtual int Index
        {
            get => _index;
            set
            {
                if (value >= 0)
                {
                    if (value < Keys.Count)
                        _index = value;
                    else
                        _index = 0;
                }
                else
                    _index = Keys.Count - 1;
            }
        }


        public delegate T GenerateNextIndex();

        public GenerateNextIndex GenerateNextIndexCustom { get; set; }


        public DictionaryHelper(IList<T> _keys)
        {
            Keys = _keys;
            Index = 0;
        }

        public void SetTail()
        {
            Index = Keys.Count - 1;
        }



        public bool IsPresentKey(T value)
        {
            return Keys.Contains(value);
        }

        public void DefaultErrorIndex()
        {
            _index = -1;
        }


        public void AddKeyList(IList<T> _keys)
        {
            foreach (T e in _keys)
                AddKeyToList(e);
        }
        public void AddKeyToList(T _keys) => Keys.Add(_keys);
        /// <summary>
        /// add new key generate troght the NextKeyGenerator to Keys List
        /// </summary>
        /// <returns>the Generated Key</returns>
        public T GenerateNextKey()
        {
            T a = GenerateNextIndexCustom();
            AddKeyToList(a);
            return a;
        }


        //
        #region Default Generation Rule

        #endregion

    }

    static public class DictionaryHelperEX
    {
        public static void SetGenerationRule_intDefault(this DictionaryHelper<int> a)
        {
            a.GenerateNextIndexCustom += () => a.Keys.Max() + 1;
        }
    }
}
