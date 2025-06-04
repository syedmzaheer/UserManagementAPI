using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UsersController : ApiController
{
    private static List<User> users = new List<User>
    {
        new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
        new User { Id = 2, Name = "Jane Doe", Email = "jane@example.com" }
    };

    // GET: Retrieve all users or a specific user by ID
    public IEnumerable<User> Get()
    {
        return users;
    }

    public IHttpActionResult Get(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    // POST: Add a new user
    public IHttpActionResult Post(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);
        return Created($"api/users/{user.Id}", user);
    }

    // PUT: Update an existing user's details
    public IHttpActionResult Put(int id, User updatedUser)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        return Ok(user);
    }

    // DELETE: Remove a user by ID
    public IHttpActionResult Delete(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
