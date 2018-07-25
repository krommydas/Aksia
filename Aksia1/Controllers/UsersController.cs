using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using DataAccess;

namespace WebApp.Controllers
{
	public class UsersController : Controller
	{
		[HttpPost]
		public ActionResult GetAll()
		{
			try
			{
				IEnumerable<User> users = UserRepository.GetAll();
				IEnumerable<UserAddress> addresses = UserAddressRepository.GetAll();

				return View(Models.UserFacade.Build(users, addresses));
			}
			// catch(BusinessLayer.AuthorizationException) // display authorization response
			catch (Exception e)
			{
				// Should return an exception relative result if the user needs to know about it.
				// Otherwise, just log the exception.
				return View();
			}
		}

		[HttpPost]
		public ActionResult Persist(Models.UserFacade user)
		{
			try
			{
				// check right to edit 

				user.Persist();

				return View();
			}
			// catch(BusinessLayer.AuthorizationException) // display authorization response
			catch (BusinessLayer.ValidationException e)
			{
				return View(e.Payload);
			}
			catch(Exception e)
			{
				// log the exception

				return View();
			}
		}

		[HttpPost]
		public ActionResult Delete(Guid userID)
		{
			try
			{
				// check right to delete 

				BusinessLayer.UserModule.Delete(userID);

				return View();
			}
			// catch(BusinessLayer.AuthorizationException) // display authorization response
			catch (BusinessLayer.ValidationException e)
			{
				return View(e.Payload);
			}
			catch (Exception e)
			{
				// log the exception

				return View();
			}
		}
	}
}