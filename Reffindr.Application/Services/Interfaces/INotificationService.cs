using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Application.Services.Interfaces
{
	public interface INotificationService
	{
		Task AddNotificationToUser(string userReceivingEmail, NotificationType status, CancellationToken cancellationToken);
	}
}
