using NUnit.Framework;
using System;
using WCS;
using System.Collections.Generic;

namespace WCSTest
{
	[TestFixture]
	public class TestEvent
	{
		[Test]
		public void TestEventPostponed()
		{
			Event newEvent = new Event("TestPresent");
			newEvent.StartTime = DateTime.Now - TimeSpan.FromMinutes(1);
			newEvent.EndTime = newEvent.StartTime + TimeSpan.FromHours(1);
			DateTime startDateBeforePostpone = newEvent.StartTime;
			DateTime endDateBeforePostpone = newEvent.EndTime;

			newEvent.Postpone(TimeSpan.FromDays(1));

			Assert.AreEqual(startDateBeforePostpone, newEvent.StartTime - TimeSpan.FromDays(1));
			Assert.AreEqual(endDateBeforePostpone, newEvent.EndTime - TimeSpan.FromDays(1));
		}

		[Test]
		public void TestGetAgenda()
		{
			Event hackathon = new Event("hackathon");
			hackathon.StartTime = new DateTime(2020, 02, 13);
			hackathon.EndTime = new DateTime(2020, 02, 15);

			Event rentree = new Event("rentrée");
			rentree.StartTime = new DateTime(2019, 12, 09);
			rentree.EndTime = new DateTime(2019, 12, 10);

			List<Event> events = new List<Event>();
			events.Add(rentree);
			events.Add(hackathon);

			AbstractPerson person = new AbstractPerson();
			person.Agenda = events;

			DateTime date1 = new DateTime(2019, 01, 10);
			DateTime date2 = new DateTime(2020, 03, 10);

			Assert.AreEqual("rentrée\nhackathon\n", person.GetEvents(date1, date2, events));
		}
	}

	[TestFixture]
	public class TestFactory
	{
		[Test]
		public void TestCreateStudents()
		{
			Cursus csharp = new Cursus();
			AbstractPerson student = PersonFactory.Create("Dan");

			string typeName = typeof(Students).ToString();
			Assert.AreEqual(typeName, student.GetType().ToString());

		}

		[Test]
		public void TestCreateInstructor()
		{
			Cursus csharp = new Cursus();
			
			List<AbstractPerson> students = new List<AbstractPerson>
			{
				new Students("Dan",  csharp)
			};
			AbstractPerson instructor = PersonFactory.Create("Instructor", students);

			string typeName = typeof(Instructor).ToString();
			Assert.AreEqual(typeName, instructor.GetType().ToString());
		}

		[Test]
		public void TestCreateLeadInstructor()
		{
			Cursus csharp = new Cursus();
			List<AbstractPerson> students = new List<AbstractPerson>
			{
				new Students("Dan", csharp)
			};

			List<AbstractPerson> instructors = new List<AbstractPerson>
			{
				new Instructor("Instrucor", students)
			};

			AbstractPerson leadInstructor = PersonFactory.Create("LeadInstructor", null, instructors);

			string typeName = typeof(LeadInstructor).ToString();
			Assert.AreEqual(typeName, leadInstructor.GetType().ToString());
		}
	}

	public class TestComposite
	{
		[SetUp]
		public void SetUp()
		{
			Cursus csharp = new Cursus();

			AbstractPerson student1 = PersonFactory.Create("Tom", null, null, csharp);
			AbstractPerson student2 = PersonFactory.Create("Lys", null, null, csharp);
			AbstractPerson student3 = PersonFactory.Create("Nathaniel", null, null, csharp);


			List<AbstractPerson> _students = new List<AbstractPerson>();

			_students.Add(student1);
			_students.Add(student2);
			_students.Add(student3);

			//List<AbstractPerson> _instructors = new List<AbstractPerson>();

			AbstractPerson _instructor = PersonFactory.Create("Instructor1", _students);
			/*Cursus csharp = new Cursus();
			_students = new List<AbstractPerson>
			{
				new Students("Tom",csharp),
				new Students("Lys", csharp),
				new Students("Nathaniel",csharp)
			};

			_instructors = new List<AbstractPerson>
			{
				new Instructor("Instructor",  _students)
			};

			_lead = new LeadInstructor("Chef", _instructors);*/

		}
		/*[Test]
		public void GetStudentsListTest()
		{
			//une méthode retourne tous les élèves d'un formateur
			Cursus csharp = new Cursus();

			AbstractPerson student1 = PersonFactory.Create("Tom", null, null, csharp);
			AbstractPerson student2 = PersonFactory.Create("Lys", null, null, csharp);
			AbstractPerson student3 = PersonFactory.Create("Nathaniel", null, null, csharp);


			List<AbstractPerson> _students = new List<AbstractPerson>();

			_students.Add(student1);
			_students.Add(student2);
			_students.Add(student3);

			//List<AbstractPerson> _instructors = new List<AbstractPerson>();

			AbstractPerson _instructor = PersonFactory.Create("Instructor1", _students);
			_instructor.GetAllStudentsOfAInstructor();

			List<string> listExpected = new List<string> { "Tom", "Lys", "Nathaniel" };
			Assert.AreEqual(listExpected,_instructor.GetAllStudentsOfAInstructor());
		}*/

	}
	
}
