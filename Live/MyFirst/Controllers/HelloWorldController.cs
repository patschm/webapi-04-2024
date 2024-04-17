using Microsoft.AspNetCore.Mvc;
using MyFirst.Model;

namespace MyFirst.Controllers;

[ApiController]
[Route("hello")]
public class HelloWorldController : ControllerBase
{
    static Person current = new Person { Id = 1, Name = "John Doe", Age = 34 };

    [HttpGet("{nummer:int}")]
   // [Route("world/{nummer:int}", Name = nameof(GetHello))]
    public ActionResult<Person> GetHello([FromRoute]int nummer = 0)
    {
        if (nummer == 0)
        {
            return NotFound();
        }
        return current;
    }

    [HttpPost]
    public ActionResult PostText([FromBody]Person person)
    {
        var rnd = new Random();
        Console.WriteLine(person.Name);
        person.Id = rnd.Next(100, 1000);
        current = person;
        return CreatedAtAction(nameof(GetHello), new { nummer=person.Id }, person);
        //return Created($"hello/{person.Id }", person);
    }
}
