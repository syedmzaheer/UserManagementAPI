public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> users = new List<User>();

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers() => users;

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id) => users.FirstOrDefault(u => u.Id == id) is User user ? Ok(user) : NotFound();

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        user.Role = updatedUser.Role;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        users.Remove(user);
        return NoContent();
    }
}
