using System;
using System.Collections.Concurrent;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ContosoModels.Models;
using ContosoUniversity.GraphQL.Types;

namespace ContosoUniversity
{
    public class CourseMessageService
    {
        private readonly ISubject<Course> _messageStream = new ReplaySubject<Course>(1);

        public CourseMessageService()
        {
            AllMessages = new ConcurrentStack<Course>();
        }


        public ConcurrentStack<Course> AllMessages { get; }


        public Course AddMessage(Course message)
        {
            AllMessages.Push(message);
            _messageStream.OnNext(message);

            return message;
        }

        public IObservable<Course> Messages()
        {
            return _messageStream.AsObservable();
        }
    }
}