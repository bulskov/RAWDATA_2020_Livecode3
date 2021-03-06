﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    static class MyUtil
    {

        public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> collection)
        {
            HashSet<T> seen = new HashSet<T>();

            foreach (var elem in collection)
            {
                if (!seen.Contains(elem))
                {
                    seen.Add(elem);
                    yield return elem;
                }
            }

        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Func<T, bool> pred)
        {
            foreach (var elem in collection)
            {
                if(pred(elem))
                yield return elem;
            }
        }

        public static IEnumerable<S> MySelect<T, S>(this IEnumerable<T> collection, Func<T, S> selector)
        {
            foreach (var elem in collection)
            {
                yield return selector(elem);
            }
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Age = {Age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var people = new List<Person>()
            {
                new Person {Id = 1, Name = "Peter", Age = 23},
                new Person {Id = 2, Name = "Sue", Age = 21},
                new Person {Id = 3, Name = "Joe", Age = 24},
                new Person {Id = 4, Name = "Ellen", Age = 20},
                new Person {Id = 5, Name = "John", Age = 26}
            };

            var numbers = new List<int>{7, 2, 23, 4, 123};

            var q = numbers.Where(x => x < 10);

            List<Person> result = new List<Person>();
            foreach (var person in people)
            {
                if(person.Age > 23)
                    result.Add(person);

            }



            var q2 = 
                people
                    .Where(p => p.Age > 23)
                    .OrderBy(p => p.Name)
                    .MySelect(p => new {p.Name, p.Age})
                    .Distinct()
                    ;

            foreach (var number in q2)
            {
                Console.WriteLine(number);
            }
        }
    }
}
