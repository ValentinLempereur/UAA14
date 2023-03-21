using System;
using System.Collections.Generic;
using System.Text;

namespace CourseDeLevriers
{
    class Person
    {
        private string _name;
        private int _money;
        private int _monPari;

        public Person(string Name, int Money, int Monpari)
        {
            _name = Name;
            _money = Money;
            _monPari = Monpari;
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }

        public int monPari
        {
            get
            {
                return _monPari;
            }
            set
            {
                _monPari = value;
            }
        }
    }
}
