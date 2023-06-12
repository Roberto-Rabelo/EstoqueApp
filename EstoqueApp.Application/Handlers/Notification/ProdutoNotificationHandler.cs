using EstoqueApp.Application.Interfaces.Persistences;
using EstoqueApp.Application.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Application.Handlers.Notification
{
    public class ProdutoNotificationHandler
        : INotificationHandler<ProdutoNotification>
    {
        private readonly IProdutoPersistence _persistenceProduto;
    

        public ProdutoNotificationHandler(IProdutoPersistence persistenceProduto)
        {
            _persistenceProduto = persistenceProduto;
        }

        public Task Handle(ProdutoNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.Action)
            {
                case ActionNotification.Create:
                    _persistenceProduto.Add(notification.Produto);
                    break;
                case ActionNotification.Update:
                    _persistenceProduto.Update(notification.Produto);
                    break;
                case ActionNotification.Delete:
                    _persistenceProduto.Delete(notification.Produto);
                    break;
            }
            //TODO enviar para o MongoDB
            return Task.CompletedTask;

        }
    }

}
