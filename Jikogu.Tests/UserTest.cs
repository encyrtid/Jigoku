﻿using System;
using System.Linq;

using NUnit.Framework;
using Jigoku.ORM.Repository;
using Jigoku.Core.Entities;
using Jigoku.Tests;
using System.Collections.Generic;

namespace Jikogu.Tests
{
    [TestFixture]
    public class UserTest
    {
        PersonRepository repository = new PersonRepository();
        Person testPerson = null;
        [SetUp]
        public void SetUpTestUser()
        {
            testPerson = new Person { NickName = "John Doe" + DateTime.Now.Ticks.ToString(), Password = DateTime.Now.Ticks.ToString(), PrimaryMail = "foo@bar.to", Projects = null, UserPhoto = null };
        }

        [Test]
        public void AddStubUser()
        {
            TestHelper.log("Adding test user John Doe");
            
            repository.Add(testPerson);

            TestHelper.log("Searching for John Doe");
            Person John = repository.GetById(testPerson.Id);
            if (John == null)
                {
                    TestHelper.error("John is not in database, problems Nhibernate ?");
                }
             Assert.IsNotNull(John);
             TestHelper.done();
        }

        [Test]
        public void DeleteStubUser()
        {
            TestHelper.log("Deleting test user John Doe");
            repository.Remove(testPerson);
            /*TestHelper.log("Searching for John Doe");
            using (var session = ConfigureRepository.SessionFactory.OpenSession())
            {
                var listPersons = session.QueryOver<Person>().List();
                //listPersons.ToList<Person>();
                Assert.AreEqual(listPersons.Count, 0);
            }*/
        }
    }
}
