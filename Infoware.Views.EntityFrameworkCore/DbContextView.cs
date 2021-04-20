﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Infoware.Views.EntityFrameworkCore
{
    public abstract class DbContextView<TDomain, TContext> : ViewBase<TDomain> where TContext : DbContext
    {
        protected TContext Context;

        public DbContextView(TDomain domain, TContext context, bool isNewRecord = false) : base(domain, isNewRecord)
        {
            Context = context;
        }

        public override bool SaveChanges()
        {
            if (IsNewRecord)
            {
                var entry = Context.Add(UpdateDomain());
                try
                {
                    Context.SaveChanges();
                    IsNewRecord = false;
                    RevertFromDomain();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                Context.Update(UpdateDomain());
                try
                {
                    Context.SaveChanges();
                    RevertFromDomain();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return true;
        }

        public override bool Remove()
        {
            Context.Remove(GetDomain());
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}
