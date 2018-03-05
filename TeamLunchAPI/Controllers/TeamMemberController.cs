using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamLunchAPI.Controllers
{
    [Produces("application/json")]
    [Route("/TeamMember")]
    public class TeamMemberController : Controller
    {
        /// <summary>
        /// GET request to return all team members. No header parameters needed.
        /// </summary>
        [HttpGet]
        [Route("/TeamMember")]
        public Dictionary<string, string> GetAll()
        {
            return Data.Instance.TeamMembers;
        }

        /// <summary>
        /// GET request to return a team member with specific id.<para/>
        /// Specify the desired id as a header parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/TeamMember/Get")]
        public KeyValuePair<string, string> Get([FromHeader] string id)
        {
            if (Data.Instance.TeamMembers.ContainsKey(id))
                return new KeyValuePair<string, string>(id, Data.Instance.TeamMembers[id]);
            else
                return new KeyValuePair<string, string>();
        }

        /// <summary>
        /// POST request to add a new team member.<para/>
        /// Specify the desired id and dietary restriction as header parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/TeamMember/Add")]
        public IActionResult Add([FromHeader] string id, [FromHeader] string restrictions)
        {

            if (!Data.Instance.TeamMembers.ContainsKey(id))
            {
                if (restrictions == null) restrictions = "";
                Data.Instance.TeamMembers.Add(id, restrictions);
                return Ok();
            }
            else
                return BadRequest();
        }


        /// <summary>
        /// PUT request to edit an existing team member.<para/>
        /// Specify the desired id and dietary restriction as header parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/TeamMember/Edit")]
        public IActionResult Edit([FromHeader] string id, [FromHeader] string restrictions)
        {
            if (Data.Instance.TeamMembers.ContainsKey(id))
            {
                if (restrictions == null) restrictions = "";
                Data.Instance.TeamMembers[id] = restrictions;
                return Ok();
            }
            else
                return BadRequest();
        }

        /// <summary>
        /// DELETE request to delete an existing team member.<para/>
        /// Specify the desired team member to delete by their id as a header parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/TeamMember/Delete")]
        public IActionResult Delete([FromHeader] string id)
        {
            if (Data.Instance.TeamMembers.ContainsKey(id))
            {
                Data.Instance.TeamMembers.Remove(id);
                return Ok();
            }
            else
                return BadRequest("Could not remove");
        }
    }
}
