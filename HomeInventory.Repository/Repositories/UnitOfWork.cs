using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeInventory.Repository.Entities;

namespace HomeInventory.Repository.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private HomeInventoryContext context = new HomeInventoryContext();
        private Repository<Home> homeRepository;
        private Repository<InventoryItem> inventoryItemRepository;
        private Repository<InventoryItemAttachment> inventoryItemAttachmentRepository;

        public Repository<Home> HomeRepository
        {
            get
            {
                if (this.homeRepository == null)
                {
                    this.homeRepository = new Repository<Home>(context);
                }
                return homeRepository;
            }
        }

        public Repository<InventoryItem> InventoryItemRepository
        {
            get
            {

                if (this.inventoryItemRepository == null)
                {
                    this.inventoryItemRepository = new Repository<InventoryItem>(context);
                }
                return inventoryItemRepository;
            }
        }

        public Repository<InventoryItemAttachment> InventoryItemAttachmentRepository
        {
            get
            {

                if (this.inventoryItemAttachmentRepository == null)
                {
                    this.inventoryItemAttachmentRepository = new Repository<InventoryItemAttachment>(context);
                }
                return inventoryItemAttachmentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
