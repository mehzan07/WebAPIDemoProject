using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemoProject.DataModel;
using static WebAPIDemoProject.Models.UserModel;

namespace WebAPIDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DemoDatabaseContext db = new DemoDatabaseContext();
        // GET: api/GetUserById
        [HttpGet]
        [Route("GetUserById")]
        public ActionResult GetUserById(int id)
        {
            try
            {
                var user = db.Set<Users>().Where(w => w.Id == id).Select(c=> new GetUserModel { 
                UserID=c.Id,
                Name=c.Name,
                Address=c.Address,
                Email=c.Email,
                PhoneNumber=c.PhoneNumber
                });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }

        // We can write both Post and Put(update) in same API
        // POST: api/PostUser
        [HttpPost]
        [Route("PostUser")]
        public ActionResult PostUser(GetUserModel userModel)
        {
            try
            {
                var userIsExist = db.Set<Users>().FirstOrDefault(w => w.Id == userModel.UserID);

                //Update block
                if (userIsExist!=null) 
                {
                    userIsExist.Name = userModel.Name;
                    userIsExist.PhoneNumber = userModel.PhoneNumber;
                    userIsExist.Email = userModel.Email;
                    userIsExist.Address = userModel.Address;
                    db.SaveChanges();
                }
                else// User not exist creaing new user
                {
                    var user = new Users();
                    // user.Id =;  auto increament in Database
                    user.Name = userModel.Name;
                    user.PhoneNumber = userModel.PhoneNumber;
                    user.Email = userModel.Email;
                    user.Address = userModel.Address;
                    user.IsActive = user.IsActive;
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }


        // DELETE: api/DeleteUserById
        [HttpDelete()]
        [Route("DeleteUserById")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var user = db.Set<Users>().FirstOrDefault(w => w.Id == id);
                if (user != null)
                {
                    user.IsActive = false;
                    db.SaveChanges();
                    return Ok();
                }
                else
                {

                    return Ok("User not Exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }
    }
}
