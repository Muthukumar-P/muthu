using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiSpaceModels;
using HiSpaceService.Models;
using Microsoft.AspNetCore.Authorization;
using HiSpaceService.ViewModel;

namespace HiSpaceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly HiSpaceContext _context;

        public UserLoginController(HiSpaceContext context)
        {
            _context = context;
        }

        // GET: api/UserLogins
        //[HttpGet("GetUserLogins")]
        [HttpGet]
        [Route("GetUserLogins")]
        public async Task<ActionResult<IEnumerable<UserLogin>>> GetUserLogins()
        {
            return await _context.UserLogins.ToListAsync();
        }

        // GET: api/UserLogins
        //[HttpGet("GetUserLogins")]
        [HttpGet]
        [Route("GetUserLoginsByClientID/{ClientID}")]
        public async Task<ActionResult<IEnumerable<UserLoginResponse>>> GetUserLoginsByClientID(int ClientID)
        {
            UserLoginResponse userDetails = new UserLoginResponse();
            if (ClientID == 0)
            {
                var result = (from U in _context.UserLogins
                              where U.UserType != 1
                              select new UserLoginResponse()
                              {
                                  UserID = U.UserID,
                                  Username = U.Username,
                                  Password = U.Password,
                                  UserType = U.UserType,
                                  UserTypeName = U.Username,
                                  Active = U.Active,
                                  MemberID = U.MemberID,
                                  MemberName = U.Username,
                                  ClientID = U.ClientID,
                                  ClientName = U.Username,
                                  ClientLocationID = U.ClientLocationID,
                                  ClientLocationName = U.Username,
                                  LastLoginDateTime = U.LastLoginDateTime,
                                  LoginCount = U.LoginCount,
                                  CreatedBy = U.CreatedBy,
                                  CreatedByName = U.Username,
                                  CreatedDateTime = U.CreatedDateTime,
                                  ModifyBy = U.ModifyBy,
                                  ModifyByName = U.Username,
                                  ModifyDateTime = U.ModifyDateTime
                              });

                return await result.ToListAsync();
            }
            else
            {
                var result = (from U in _context.UserLogins
                              where U.UserType != 1 && U.UserType != 4 && U.ClientID == ClientID
                              select new UserLoginResponse()
                              {
                                  UserID = U.UserID,
                                  Username = U.Username,
                                  Password = U.Password,
                                  UserType = U.UserType,
                                  UserTypeName = U.Username,
                                  Active = U.Active,
                                  MemberID = U.MemberID,
                                  MemberName = U.Username,
                                  ClientID = U.ClientID,
                                  ClientName = U.Username,
                                  ClientLocationID = U.ClientLocationID,
                                  ClientLocationName = U.Username,
                                  LastLoginDateTime = U.LastLoginDateTime,
                                  LoginCount = U.LoginCount,
                                  CreatedBy = U.CreatedBy,
                                  CreatedByName = U.Username,
                                  CreatedDateTime = U.CreatedDateTime,
                                  ModifyBy = U.ModifyBy,
                                  ModifyByName = U.Username,
                                  ModifyDateTime = U.ModifyDateTime
                              });

                var rs = result.ToList();

                return await result.ToListAsync();
            }

            //if (ClientID == 0)
            //    return await _context.UserLogins.Where(d => d.UserType != 1).ToListAsync();
            //else
            //    return await _context.UserLogins.Where(d => d.UserType != 1 && d.ClientID == ClientID).ToListAsync();
        }

        // GET: api/UserLogins/5
        [HttpGet("GetUserLogin/{UserID}")]
        public async Task<ActionResult<UserLogin>> GetUserLogin(int UserID)
        {
            var userLogin = await _context.UserLogins.FindAsync(UserID);

            if (userLogin == null)
            {
                return NotFound();
            }

            return userLogin;
        }



        // PUT: api/UserLogins/5
        [HttpPut("UpdateUserLogin/{UserID}")]
        public async Task<ActionResult<bool>> UpdateUserLogin(int UserID, [FromBody] UserLogin userLogin)
        {
            if (UserID != userLogin.UserID || userLogin == null)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(UserID))
                {
                    //return NotFound();
                    return false;
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return true;
        }

        // POST: api/UserLogins
        [HttpPost]
        [Route("AddUserLogin")]
        public async Task<ActionResult<UserLogin>> AddUserLogin([FromBody] UserLogin userLogin)
        {

            if (!_context.UserLogins.Any(d => d.Username == userLogin.Username))
            {
                _context.UserLogins.Add(userLogin);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NoContent();
            }

            return CreatedAtAction("GetUserLogin", new { UserID = userLogin.UserID }, userLogin);
        }


        [HttpPost("SignupUser")]
        public async Task<ActionResult<bool>> SignupUser([FromBody] SignupUser user)
        {
            bool result = false;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    if (user.IsClient)
                    {
                        if (!_context.ClientMasters.Any(d => d.ClientName == user.Username))
                        {
                            ClientMaster cl = new ClientMaster();
                            cl.ClientName = user.Username;
                            _context.ClientMasters.Add(cl);
                            await _context.SaveChangesAsync();

                            //ClientMaster newClient =  CreatedAtAction("GetClient", new { ClientID = client.clientMaster }, client);

                            if (!_context.UserLogins.Any(d => d.Username == user.Username))
                            {
                                UserLogin ur = new UserLogin();
                                ur.Username = user.Username;
                                ur.Password = user.Password;
                                ur.UserType = 2;
                                ur.ClientID = cl.ClientID;
                                _context.UserLogins.Add(ur);
                                await _context.SaveChangesAsync();
                            }

                            result = true;
                        }
                    }
                    else
                    {
                        if (!_context.Members.Any(d => d.MemberName == user.Username))
                        {
                            MemberMaster me = new MemberMaster();
                            me.MemberName = user.Username;
                            _context.Members.Add(me);
                            await _context.SaveChangesAsync();

                            //ClientMaster newClient =  CreatedAtAction("GetClient", new { ClientID = client.clientMaster }, client);

                            if (!_context.UserLogins.Any(d => d.Username == user.Username))
                            {
                                UserLogin ur = new UserLogin();
                                ur.Username = user.Username;
                                ur.Password = user.Password;
                                ur.UserType = 4;
                                ur.MemberID = me.MemberID;
                                _context.UserLogins.Add(ur);
                                await _context.SaveChangesAsync();
                            }

                            result = true;
                        }
                    }

                    trans.Commit();
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    result = false;
                }
            }
            return result;
        }

        // GET: http://1.1.1.1/BMW/api/UserLogins/UserLoginExist

        [HttpPost("AuthenticateUser")]
        //[Route("AuthenticateUser")]
        //public IActionResult AuthenticateUser([FromBody] UserLogin userLogin)
        public async Task<ActionResult<UserLogin>> AuthenticateUser([FromBody] UserLogin userLogin)
        //public async Task<ActionResult<UserLogin>> AuthenticateUser([FromQuery] string Username, [FromQuery] string Password)
        {

            //var _userLogin = await _context.UserLogins.FindAsync(userLogin.Username, userLogin.Password);
            var _userLogin = await _context.UserLogins.FirstOrDefaultAsync(d => d.Username == userLogin.Username && d.Password == userLogin.Password && d.Active);
            //var _userLogin = await _context.UserLogins.FirstOrDefaultAsync(d => d.Username == Username && d.Password == Password);


            if (_userLogin == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
                //return NotFound();
                //return _userLogin;
                //return false;
            }
            else
            {
                _userLogin.LoginCount = _userLogin.LoginCount + 1;
                _userLogin.LastLoginDateTime = DateTime.Now;
                _context.Entry(_userLogin).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return Ok(new
            {
                UserId = _userLogin.UserID,
                Username = _userLogin.Username,
                Password = _userLogin.Password,
                ClientID = _userLogin.ClientID,
                MemberID = _userLogin.MemberID,
                UserType = _userLogin.UserType,
                ClientLocationID = _userLogin.ClientLocationID
            });

            //return _userLogin;
            //return "Succes..";
            //return true;

            //return userDetails;
        }

        [HttpGet("AuthenticateUserText")]
        public async Task<ActionResult<string>> AuthenticateUserText([FromQuery] string Username, [FromQuery] string Password)
        {
            var _userLogin = await _context.UserLogins.FirstOrDefaultAsync(d => d.Username == Username && d.Password == Password);

            if (_userLogin == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            _userLogin.LoginCount = _userLogin.LoginCount + 1;
            _userLogin.LastLoginDateTime = DateTime.Now;
            _context.Entry(_userLogin).State = EntityState.Modified;
            await _context.SaveChangesAsync();


            return "Succes";
        }

        private bool UserLoginExists(int id)
        {
            return _context.UserLogins.Any(e => e.UserID == id);
        }

    }
}
