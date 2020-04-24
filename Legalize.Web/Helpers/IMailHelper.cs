using Legalize.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Helpers
{
	public interface IMailHelper
	{
		Response SendMail(string to, string subject, string body);
	}

}
