﻿using EstoqueApp.Application.Interfaces.Persistences;
using EstoqueApp.Application.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Application.Handlers.Notification
{
    public class EstoqueNotificationHandler
          : INotificationHandler<EstoqueNotification>
    {
        private readonly IEstoquePersistence? _estoquePersistence;

        public EstoqueNotificationHandler(IEstoquePersistence? estoquePersistence)
        {
            _estoquePersistence = estoquePersistence;
        }

        public Task Handle(EstoqueNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.Action)
            {
                case ActionNotification.Create:
                    _estoquePersistence.Add(notification.Estoque);
                    break;
                case ActionNotification.Update:
                    _estoquePersistence.Update(notification.Estoque);
                    break;
                case ActionNotification.Delete:
                    _estoquePersistence.Delete(notification.Estoque);
                    break;
            }

            return Task.CompletedTask;
        }


    }
}