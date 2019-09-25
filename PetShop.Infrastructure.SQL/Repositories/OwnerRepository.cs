﻿using Core.DomainServices;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private PetShopContext _context;

        public OwnerRepository(PetShopContext context)
        {
            _context = context;
        }
        public Owner AddOwner(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
            return owner;
        }

        public Owner ReadOwner(int id)
        {
            return _context.Owners
                .Include(o => o.petHistory)
                .ThenInclude(po => po.Pet)
                .FirstOrDefault(o => o.id == id);
        }

        public IEnumerable<Owner> ReadOwners(Filter filter)
        {
            if (filter == null)
            {
                return _context.Owners.
                                Include(o => o.petHistory)
                                .ThenInclude(po => po.Pet).ToList();
            }

            return _context.Owners.Include(o => o.petHistory)
                .ThenInclude(po => po.Pet)
                .Skip((filter.CurrentPage - 1) * filter.InfoPrPage)
                .Take(filter.InfoPrPage).ToList();
        }

        public Owner UpdateOwner(Owner toBeUpdated, Owner updatedOwner)
        {
            _context.Attach(toBeUpdated).State = EntityState.Modified;
            _context.Entry(toBeUpdated).Reference(o => o.petHistory).IsModified = true;
            _context.SaveChanges();

            updatedOwner = toBeUpdated;
            return updatedOwner;
        }

        public int Count()
        {
            return _context.Owners.Count();
        }
    }
}
